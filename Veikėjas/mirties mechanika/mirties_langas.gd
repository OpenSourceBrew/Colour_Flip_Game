extends CanvasLayer

var checkpoint_manager
var player

func _ready():
	self.hide()
	checkpoint_manager = get_parent().get_node("CheckpointManager")
	player = get_parent().get_node("CharacterBody2D")
	 
func _on_retry_pressed() -> void:
	get_tree().paused = false
	player.position = checkpoint_manager.last_location

func game_over():
	get_tree().paused = true
	self.show()
