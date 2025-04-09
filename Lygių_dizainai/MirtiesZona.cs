using Godot;
using System;

public partial class MirtiesZona : Area2D // Replace with the actual node type if needed
{
	public override void _Ready()
	{

	}


	public override void _Process(double delta)
	{
		// Called every frame. 'delta' is the elapsed time since the previous frame.
	}

	private void _on_body_entered(Node2D body)
	{
		if (body is CharacterBody2D)
		{
			var deathWindow = GetNode("../CanvasLayer2/MirtiesLangas") as Node;
			deathWindow?.Call("TestDeath");
		}
	}
}
