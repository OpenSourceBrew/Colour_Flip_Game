using Godot;
using System;

public partial class IstorijosLangas : Control
{
	private AudioStreamPlayer backgroundMusic;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var existingMusic = GetTree().Root.GetNodeOrNull<AudioStreamPlayer>("BackgroundMusic");

		if (existingMusic == null)
		{
			backgroundMusic = GetNode<AudioStreamPlayer>("BackgroundMusic");
			backgroundMusic.Stream = GD.Load<AudioStream>("res://Muzika/Foninė_muzika/menu_music.mp3");
			backgroundMusic.VolumeDb = -6; // Galima pareguliuoti garsą
			backgroundMusic.Name = "BackgroundMusic";
			backgroundMusic.Play();
		}
		else
		{
			backgroundMusic = existingMusic;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void _on_pradetizaidima_pressed()
	{
		// Muziką sustabdom ir ištrinam
		var music = GetTree().Root.GetNodeOrNull<AudioStreamPlayer>("BackgroundMusic");
		if (music != null)
		{
			music.Stop();
			music.QueueFree(); // pašalinam meniu muziką visiškai
		}
		GetTree().ChangeSceneToFile("res://Lygių_dizainai/1_Lygis.tscn");
	}
}
