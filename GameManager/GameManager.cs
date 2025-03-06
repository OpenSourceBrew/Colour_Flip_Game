using Godot;
using System;

public partial class GameManager : Node
{
	public static GameManager Instance { get; private set; } // Singleton instance
	
	private Label infoLabel;
	private int score = 0;
	private int currentLevel = 1;  // Start at Level 1
	private int totalLevels = 4;   // Total number of levels
	
	public override void _Ready()
	{
		//infoLabel = GetNodeOrNull<Label>("/root/Node2/UI/Panel/InfoLabel");
		if (Instance == null)
			Instance = this;
		else
		{
			QueueFree(); // Prevent duplicate instances
			return;
		}

		infoLabel = GetNodeOrNull<Label>("/root/Node2/UI/Panel/InfoLabel");
		UpdateLevelLabel();
	}
	public void AddPoint()
	{
		score++;
		UpdateLevelLabel(); // Update UI after scoring
	}
	public void NextLevel()
	{
		if (currentLevel < totalLevels)
		{
			currentLevel++;
			UpdateLevelLabel();
			GetTree().ChangeSceneToFile($"res://Levels/Level{currentLevel}.tscn"); // Load next level
		}
		else
		{
			GD.Print("Game Completed!");
			// Optionally, load a "You Win" screen
			GetTree().ChangeSceneToFile("res://Levels/VictoryScreen.tscn");
		}
	}

	private void UpdateLevelLabel()
	{
		if (infoLabel != null)
		{
			infoLabel.Text = $"Points: {score}\nLevel: {currentLevel}/{totalLevels}";
		}
		else
		{
			GD.PrintErr("ERROR: infoLabel not found!");
		}
	}
}
