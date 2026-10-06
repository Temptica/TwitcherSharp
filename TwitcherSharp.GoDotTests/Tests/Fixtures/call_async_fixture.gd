extends RefCounted
## Functions with every kind of result CallAsync has to handle.

## The last object object() returned, without keeping it alive.
var last_object: WeakRef


func plain() -> int:
	return 42


## Typed object returns hand C# an Object Variant that holds null.
func null_object() -> RefCounted:
	return null


func untyped_null():
	return null


func object() -> RefCounted:
	var result := RefCounted.new()
	result.set_meta(&"name", "object")
	last_object = weakref(result)
	return result


func last_object_alive() -> bool:
	return last_object != null and last_object.get_ref() != null


func awaiting() -> String:
	await (Engine.get_main_loop() as SceneTree).process_frame
	return "awaited"


func awaiting_object() -> RefCounted:
	await (Engine.get_main_loop() as SceneTree).process_frame
	return object()


func awaiting_null() -> RefCounted:
	await (Engine.get_main_loop() as SceneTree).process_frame
	return null
