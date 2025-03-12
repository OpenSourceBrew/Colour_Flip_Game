using Godot;
using System;

public partial class Portal : Node
{
	private AnimatedSprite2D sprite2D;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		sprite2D.Play("default");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_body_entered(Node2D body)
	{
		if (body.IsInGroup("Player"))
		{
			string currentSceneFile = GetTree().CurrentScene.SceneFilePath;
			string fileName = currentSceneFile.GetFile(); // Extracts "1Lygis.tscn"
			string levelNumberStr = fileName.Split('_')[0]; // Extracts "1"

			if (int.TryParse(levelNumberStr, out int currentLevelNumber))
			{
				int nextLevelNumber = currentLevelNumber + 1;
				string nextLevelPath = $"res://Lygių_dizainai/{nextLevelNumber}_Lygis.tscn";
				GetTree().ChangeSceneToFile(nextLevelPath);
			}
			else
			{
				GD.PrintErr($"Failed to extract level number from file name: {fileName}");
			}
		}
	}
}
