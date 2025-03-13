using Godot;
using System;

public partial class GameManager : Node
{
	public static GameManager Instance { get; private set; } // Singleton instance
	private AudioStreamPlayer backgroundMusic;
	//private Label infoLabel;
	//private int score = 0;
	//private int currentLevel = 1;
	//private int totalLevels = 4;

	public override void _Ready()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			QueueFree();
			return;
		}
		// Prevent GameManager from being removed when changing levels
		SetDeferred("process_mode", (int)ProcessModeEnum.Always);
		
		CreateDefaultMusic();
		
		//infoLabel = GetNodeOrNull<Label>("/root/Node2/UI/Panel/InfoLabel");
		//UpdateLevelLabel();
	}
	// Method to change music for different levels
	public void ChangeMusicForLevel(int level)
	{
		string musicPath = $"res://Muzika/Foninė_muzika/music_level{level}.mp3"; // Adjust as needed

		if (ResourceLoader.Exists(musicPath) && IsInstanceValid(backgroundMusic))
		{
			backgroundMusic.Stream = GD.Load<AudioStream>(musicPath);
			backgroundMusic.Play();
			//GD.Print($"Playing music for level {level}: {musicPath}");
		}
		else
		{
			GD.PrintErr($"ERROR: Music file not found for level {level} at {musicPath}!");
		}
	}
	public void CreateDefaultMusic()
	{
		//If AudioStreamPlayer does not exist, create and add it
		if (backgroundMusic == null)
		{
			backgroundMusic = new AudioStreamPlayer();
			backgroundMusic.Name = "AudioStreamPlayer";
			AddChild(backgroundMusic);
		}
		else
		{
			GD.PrintErr($"ERROR: Failed to create new AudioStreamPlayer!");
		}
		
		string defaultMusicPath = "res://Muzika/Foninė_muzika/music_level1.mp3";
		if (ResourceLoader.Exists(defaultMusicPath) && IsInstanceValid(backgroundMusic))
		{
			backgroundMusic.Stream = (AudioStream)GD.Load(defaultMusicPath);
			//await ToSignal(GetTree().CreateTimer(6.0f), "timeout"); // Wait 5 seconds
			backgroundMusic.Play();
			backgroundMusic.VolumeDb = -10f;
		}
		else
		{
			GD.PrintErr($"ERROR: Default music file not found at {defaultMusicPath}!");
		}
	}
	//public void AddPoint()
	//{
		//score++;
		//UpdateLevelLabel();
	//}

	//public void NextLevel()
	//{
		//if (currentLevel < totalLevels)
		//{
			//currentLevel++;
			//ChangeMusicForLevel(currentLevel);
			//UpdateLevelLabel();
			//GetTree().CallDeferred("ChangeSceneToFile", $"res://Levels/Level{currentLevel}.tscn");
		//}
		//else
		//{
			//GD.Print("Game Completed!");
			//GetTree().ChangeSceneToFile("res://Levels/VictoryScreen.tscn");
		//}
	//}
	
	//private void UpdateLevelLabel()
	//{
		//if (IsInstanceValid(infoLabel))
		//{
			//infoLabel.Text = $"Points: {score}\nLevel: {currentLevel}/{totalLevels}";
		//}
		//else
		//{
			//GD.PrintErr("ERROR: infoLabel not found!");
		//}
	//}
}
