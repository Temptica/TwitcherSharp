using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Godot;
using Newtonsoft.Json;
using TwitcherSharp.Lib.OOuch;
using Environment = System.Environment;
using HttpClient = System.Net.Http.HttpClient;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TwitcherSharp.GoDotTests.Helper;

public static class TwitchMockupHelper
{
    public static string Url => "http://localhost:8080/mock";
    public static string ClientUrl => "http://localhost:8080/units/clients";
    public static string AuthUrl => "http://localhost:8080/auth/authorize";
    public static string UsersUrl => "http://localhost:8080/units/users";

    /// <summary>
    /// The mock user the tests act as. The mock database is generated per machine, so it is read from the mock.
    /// </summary>
    public static string UserId { get; private set; }
    private static Process _process;

    /// <summary>
    /// The scopes the test token carries. The mock rejects legacy scopes like chat:read, so this is not the scene's list.
    /// </summary>
    private static readonly string[] TestScopes = ["moderator:read:followers", "user:read:email"];

    /// <summary>
    /// The mock's client id; the scene's OAuth setting has to send it, because the mock database is generated per machine.
    /// </summary>
    public static string ClientId { get; private set; }

    public static async Task<AccessResponse> AwaitForStart()
    {
        for (var i = 0; i < 60; i++)
        {
            try
            {
                using var client = new HttpClient();
                var response = await client.GetAsync(ClientUrl);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var clientResponse = JsonConvert.DeserializeObject<ClientResponse>(json);
                    ClientId = clientResponse.Data[0].Id;
                    var usersJson = await client.GetStringAsync(UsersUrl);
                    UserId = JsonConvert.DeserializeObject<ClientResponse>(usersJson).Data[0].Id;
                    var scopesString = string.Join("%20", TestScopes);
                    var querystring =
                        $"?client_id={clientResponse.Data[0].Id}&client_secret={clientResponse.Data[0].Secret}&grant_type=user_token&user_id={UserId}&scope={scopesString}";
                    var accessResponse = await client.PostAsync(AuthUrl + querystring, null);
                    var accessJson = await accessResponse.Content.ReadAsStringAsync();
                    var accessResponseObject = JsonConvert.DeserializeObject<AccessResponse>(accessJson);
                   // accessResponseObject.Scope = scopes;
                    return accessResponseObject;
                }
            }
            catch
            {
                // not ready yet
                if (i == 0)
                {
                    // run cmd twitch mock-api start 
                    Start();
                }
            }

            await Task.Delay(1000);
        }

        throw new Exception("Start failed");
    }

    private static void Start()
    {
        try
        {
            var startInfo = new ProcessStartInfo
            {
                // The Twitch CLI from PATH; TWITCH_CLI overrides it.
                FileName = Environment.GetEnvironmentVariable("TWITCH_CLI") ?? "twitch",
                Arguments = "mock-api start",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = Environment.CurrentDirectory
            };

            _process = new Process { StartInfo = startInfo };

            // Log output in the background so it doesn't block
            _process.OutputDataReceived += (s, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                    Console.WriteLine($"[Twitch Mock]: {e.Data}");
            };

            _process.Start();
            _process.BeginOutputReadLine();

            Console.WriteLine("Background process kicked off!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public static void Stop()
    {
        if (_process is { HasExited: false })
        {
            _process.Kill();
            _process.Dispose();
        }
    }
}

public class ClientResponse()
{
    [JsonPropertyName("cursor")]
    public string Cursor { get; set; }
    [JsonPropertyName("total")]
    public int Total { get; set; }
    [JsonPropertyName("data")]
    public DataObject[] Data { get; set; }

    public class DataObject
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("secret")]
        public string Secret { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("is_extension")]
        public bool IsExtension { get; set; }
    }
}

public class AccessResponse
{
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    [JsonProperty("refresh_token")]
    public string RefreshToken { get; set; }

    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonProperty("token_type")]
    public string TokenType { get; set; }

    [JsonProperty("scope")]
    public string[] Scope { get; set; }
}