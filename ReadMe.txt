-This is a base scripts for the first person movement. For usage you need this following hierarchy:

->Parent Object (has animator, character controller and camera controller scripts, rigidbody and capsule collider)
	->Main Camera (standart unity camera)
	->Character Mesh
	->Armature


-Giving reference of player to the cam controller scripts is mandatory for now. Camera reference is optional if you are using more than
single camera.
-All the values for movement and camera behavior is editable (also for jump and movement speeds). You can change them.