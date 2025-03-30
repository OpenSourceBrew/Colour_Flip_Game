using Godot;
using System;

public partial class PradžiosLangas : Control
{
	private AudioStreamPlayer backgroundMusic;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		backgroundMusic = GetNode<AudioStreamPlayer>("BackgroundMusic");
		backgroundMusic.Stream = GD.Load<AudioStream>("res://Muzika/Foninė_muzika/menu_music.mp3");
		backgroundMusic.Play();
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
		// Stop any currently playing music
		if (backgroundMusic.Playing)
		{
			backgroundMusic.Stop();
			GD.Print("Stopped current music.");
		}
		string defaultMusicPath = "res://Muzika/Foninė_muzika/music_level1.mp3";
		if (ResourceLoader.Exists(defaultMusicPath) && IsInstanceValid(backgroundMusic))
		{
			backgroundMusic.Stream = (AudioStream)GD.Load(defaultMusicPath);
			backgroundMusic.VolumeDb = -10f;
			backgroundMusic.Play();
		}
		else
		{
			GD.PrintErr($"ERROR: Default music file not found at {defaultMusicPath}!");
		}
	}
	
	// Called when the node enters the scene tree for the first time.

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void _on_pradeti_pressed()
	{
		GetTree().ChangeSceneToFile("res://Lygių_dizainai/1_Lygis.tscn");
	}
	
	public void _on_nustatymai_pressed()
	{
		GetTree().ChangeSceneToFile("res://Interaktyvūs_langai/Instrukcijų_langas/instrukcijų_langas.tscn");
	}
	
	public void _on_iseiti_pressed()
	{
		GetTree().Quit();
	}
	
}
