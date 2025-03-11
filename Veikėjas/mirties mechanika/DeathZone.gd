extends Area2D

var player
var checkpoint_manager
# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	checkpoint_manager = get_parent().get_node("CheckpointManager")
	player = get_parent().get_node("Player")


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass


func _on_body_entered(body: Node2D) -> void:
	if body.is_in_group("Player"):
		killPlayer()
		
func killPlayer():
	player.position = checkpoint_manager.last_location
