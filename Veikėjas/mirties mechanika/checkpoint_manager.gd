extends Node

var last_location
var player

func _ready() -> void:
	player = get_parent().get_node("CharacterBody2D")
	last_location = player.global_position
