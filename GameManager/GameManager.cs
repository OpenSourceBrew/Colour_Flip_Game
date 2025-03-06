using Godot;
using System;

public partial class GameManager : Node
{
	public static GameManager Instance { get; private set; } // Singleton instance
	private AudioStreamPlayer backgroundMusic;
	private Label infoLabel;
	private int score = 0;
	private int currentLevel = 1;  // Start at Level 1
	private int totalLevels = 4;   // Total number of levels
	
	public override void _Ready()
	{
		//infoLabel = GetNodeOrNull<Label>("/root/Node2/UI/Panel/InfoLabel");
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			QueueFree(); // Prevent duplicate instances
			return;
		}
		// Get background music node
		backgroundMusic = GetNodeOrNull<AudioStreamPlayer>("/root/Node2/BackgroundMusic");
		
		if (backgroundMusic != null && !backgroundMusic.Playing)
		{
			backgroundMusic.Play(); // ✅ Start music at game launch
		}
		else
		{
			GD.PrintErr("ERROR: BackgroundMusic node not found!");
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
			
			// Change music if needed
			ChangeMusicForLevel(currentLevel);
			
			UpdateLevelLabel();
			// Load next level without resetting music
			GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>($"res://Levels/Level{currentLevel}.tscn"));
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
	//private void ChangeMusicForLevel(int level)
	//{
		////  Use a dictionary to set different music for each level
		//var levelMusic = new Dictionary<int, string>
		//{
			//{ 1, "res://Muzika/level1.mp3" },
			//{ 2, "res://Muzika/level2.mp3" },
			//{ 3, "res://Muzika/level3.mp3" },
			//{ 4, "res://Muzika/level4.mp3" }
		//};
//
		//if (levelMusic.ContainsKey(level) && ResourceLoader.Exists(levelMusic[level]))
		//{
			//backgroundMusic.Stream = (AudioStream)GD.Load(levelMusic[level]);
			//backgroundMusic.Play();
			//GD.Print($"Now playing: {levelMusic[level]}");
		//}
		//else
		//{
			//GD.PrintErr($"ERROR: Music file not found for Level {level}");
		//}
	//}
	private void ChangeMusicForLevel(int level)
	{
		string musicPath = $"res://Muzika/zapsplat_fantasy_psychic_light_bright_shimmering_magical_104509.mp3";
		
		if (ResourceLoader.Exists(musicPath))
		{
			backgroundMusic.Stream = (AudioStream)GD.Load(musicPath);
			backgroundMusic.Play();
		}
	}
}
