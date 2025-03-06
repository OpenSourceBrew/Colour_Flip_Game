using Godot;
using System;

public partial class Collectable : Area2D
{
	private GameManager gameManager;

	public override void _Ready()
	{
		gameManager = (GameManager)GetTree().Root.GetNode("GameManager");
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
	}

	private void OnBodyEntered(Node body)
	{
		if (body is CharacterBody2D)
		{
			QueueFree();
			gameManager?.AddPoint();
		}
	}
}
