extends Area2D

var sprite2D: AnimatedSprite2D

func _ready():
	sprite2D = $AnimatedSprite2D
	sprite2D.play("default")


func _on_body_entered(body: Node2D):
	if body.is_in_group("Player"):
		var current_scene_file = get_tree().current_scene.scene_file_path
		var next_level_number = current_scene_file.to_int() + 1
		var next_level_path = "res://Lygių_dizainai/" + str(next_level_number) + "_Lygis" + ".tscn"
		get_tree().change_scene_to_file(next_level_path)
