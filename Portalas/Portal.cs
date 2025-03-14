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

	private  void _on_body_entered(Node2D body)
	{
		if (body.IsInGroup("Player"))
		{
			string currentSceneFile = GetTree().CurrentScene.SceneFilePath;
			string fileName = currentSceneFile.GetFile();
			string levelNumberStr = fileName.Split('_')[0];

			if (int.TryParse(levelNumberStr, out int currentLevelNumber))
			{
				int nextLevelNumber = currentLevelNumber + 1;
				string nextLevelPath = $"res://Lygių_dizainai/{nextLevelNumber}_Lygis.tscn";
				
				GetTree().CallDeferred("change_scene_to_file", nextLevelPath);
			}
			else
			{
				GD.PrintErr($"Failed to extract level number from file name: {fileName}");
			}
		}
	}
}
