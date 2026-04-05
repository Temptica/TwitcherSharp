using Godot;
using TwitcherSharp.Chat;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Reward;

namespace TwitcherSharp.Extensions;

public static class NodeExtension
{
    private const string MetaKey = "_twitcher_sharp_instance";

    extension(Node node)
    {
        /// <summary>
        /// Adds the refCounted TwitcherSharp object to the meta data. This allows for easier retrieval and management of TwitcherSharp instances within the node.
        /// </summary>
        /// <param name="twitcherObject"></param>
        /// <typeparam name="T"></typeparam>
        public void SetTwitcherSharp<T>(T twitcherObject) where T : RefCounted, ITwitcherSharp<T>
        {
            node.SetMeta(MetaKey, twitcherObject);
        }

        /// <summary>
        /// returns whether there is a TwitcherSharp object linked.
        /// </summary>
        /// <returns></returns>
        public bool HasTwitcherSharp()
        {
            return node.GetMetaList().Contains(MetaKey);
        }

        /// <summary>
        /// Gets the linked TwitcherSharp object. If none is linked, it returns null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetTwitcherSharp<T>() where T : RefCounted, ITwitcherSharp<T>
        {
            if (node.HasTwitcherSharp())
            {
                return node.GetMeta(MetaKey).Obj as T;
            }

            return null;
        }

        /// <summary>
        /// Gets the TwitcherSharp object.
        /// </summary>
        /// <param name="twitcherObject"></param>
        /// <typeparam name="T">The typed TwitcherSharp object</typeparam>
        /// <returns>True if successful, false otherwise</returns>
        public bool TryGetTwitcherSharp<T>(out T twitcherObject) where T : RefCounted, ITwitcherSharp<T>
        {
            twitcherObject = null;
            if (!node.HasTwitcherSharp()) return false;

            twitcherObject = node.GetMeta(MetaKey).Obj as T;
            return twitcherObject != null;
        }

        public void RemoveTwitcherSharp()
        {
            node.RemoveMeta(MetaKey);
        }

        /// <summary>
        /// Will try to get the TwitcherSharp object from a Godot node's meta-data.
        /// <p>If no object is found within the meta-data, it will create a new one based on the node and set it to the node's meta-data.</p>
        /// <p>If a node can't be found or bound, it will return null</p>
        /// </summary>
        /// <param name="path">The absolute or relative path to the node</param>
        /// <typeparam name="T"> a <see cref="RefCounted"/> <see cref="ITwitcherSharp&lt;T&gt;"/></typeparam>
        /// <returns>Returns the TwitcherSharp object when successful, or null if the node cannot be found or bound</returns>
        public T GetOrCreateTwitcherNode<T>(NodePath path)
            where T : RefCounted, ITwitcherSharp<T>
        {
            var twitcherNode = node.GetNode(path);
            if (twitcherNode == null)
            {
                return null;
            }

            // Node Exists
            if (twitcherNode.TryGetTwitcherSharp(out T twitcherSharp))
            {
                return twitcherSharp;
            }

            twitcherSharp = T.FromObject(twitcherNode);
            twitcherNode.SetTwitcherSharp(twitcherSharp);

            return twitcherSharp;
        }
        
        public T GetTwitcherNode<T>(NodePath path) where T : RefCounted, ITwitcherSharp<T>
        {
            var twitcherNode = node.GetNode(path);
            return twitcherNode?.GetTwitcherSharp<T>();
        }
    }
}