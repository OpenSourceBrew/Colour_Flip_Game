using Godot;
using System;

public partial class GameManager : Node
{
	//public static GameManager Instance { get; private set; }
	//private AudioStreamPlayer backgroundMusic;
	//private Label infoLabel;
	////private int score = 0;
	////private int playerHealth = 3; // ✅ Add Player Health
	//private int currentLevel = 1;
	//private int totalLevels = 4;
	//
	public override void _Ready()
	{
		//if (Instance == null)
		//{
			//Instance = this;
		//}
		//else
		//{
			//QueueFree();
			//return;
		//}
		//SetDeferred("process_mode", (int)ProcessModeEnum.Always);
		//CreateDefaultMusic();
		//
		//infoLabel = GetNodeOrNull<Label>("/root/UI/CanvasLayer/InfoLabel");
		//if (infoLabel == null)
		//{
			//GD.PrintErr("InfoLabel not found!");
		//}
		//DetectCurrentLevel();
		//UpdateLevelLabel();
	}
	//public override void _Process(double delta)
	//{
		//if (infoLabel == null) 
		//{
			//infoLabel = GetNodeOrNull<Label>("/root/UI/CanvasLayer/Label");
			//if (infoLabel != null)
			//{
				//GD.Print("InfoLabel found successfully!");
				//DetectCurrentLevel(); // ✅ Now detect the level and update visibility
				//UpdateLevelLabel();
			//}
		//}
	//}
	// Method to dinamically update player info label in different levels
	//private void UpdateLevelLabel()
	//{
		//if (infoLabel != null && IsInstanceValid(infoLabel))
		//{
			//infoLabel.Text = $"Žaidimo lygis: {currentLevel} / {totalLevels}";
		//}
		//else
		//{
			//GD.PrintErr("ERROR: infoLabel not found!");
		//}
	//}
	//// Method to change music for different levels
	//public void ChangeMusicForLevel(int level)
	//{
		//string musicPath = $"res://Muzika/Foninė_muzika/music_level{level}.mp3";
//
		//if (ResourceLoader.Exists(musicPath) && IsInstanceValid(backgroundMusic))
		//{
			//backgroundMusic.Stream = GD.Load<AudioStream>(musicPath);
			//backgroundMusic.Play();
		//}
		//else
		//{
			//GD.PrintErr($"ERROR: Music file not found for level {level} at {musicPath}!");
		//}
	//}
	//public void CreateDefaultMusic()
	//{
		////If AudioStreamPlayer does not exist, create and add it
		//if (backgroundMusic == null)
		//{
			//backgroundMusic = new AudioStreamPlayer();
			//backgroundMusic.Name = "AudioStreamPlayer";
			//AddChild(backgroundMusic);
		//}
		//else
		//{
			//GD.PrintErr($"ERROR: Failed to create new AudioStreamPlayer!");
		//}
		//
		//string defaultMusicPath = "res://Muzika/Foninė_muzika/music_level1.mp3";
		//if (ResourceLoader.Exists(defaultMusicPath) && IsInstanceValid(backgroundMusic))
		//{
			//backgroundMusic.Stream = (AudioStream)GD.Load(defaultMusicPath);
			////await ToSignal(GetTree().CreateTimer(6.0f), "timeout"); // Wait 5 seconds
			//backgroundMusic.Play();
			//backgroundMusic.VolumeDb = -10f;
		//}
		//else
		//{
			//GD.PrintErr($"ERROR: Default music file not found at {defaultMusicPath}!");
		//}
	//}
	//private void DetectCurrentLevel()
	//{
		//string currentSceneFile = GetTree().CurrentScene.SceneFilePath;
		//string fileName = currentSceneFile.GetFile().ToLower();
		//if (fileName.ToLower().Contains("pradžios_langas"))
		//{
			//GD.Print("Skipping level detection: Start Menu scene.");
			//return;
		//}
		//string levelNumberStr = fileName.Split('_')[0];
//
		//if (int.TryParse(levelNumberStr, out int detectedLevel))
		//{ 
			//GD.Print($"Detected level: {detectedLevel}");
			//SetCurrentLevel(detectedLevel);
		//}
		//else
		//{
			//GD.PrintErr($"Failed to detect level from file name: {fileName}");
		//}
	//}
	////Do not change anything here!
	//public void SetCurrentLevel(int newLevel)
	//{
		//currentLevel = newLevel;
		//UpdateLevelLabel();
	//}
}
