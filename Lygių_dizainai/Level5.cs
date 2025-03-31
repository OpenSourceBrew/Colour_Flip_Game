using Godot;
using System;

public partial class Level5 : LevelBase
{
	private AudioStreamPlayer backgroundMusic;
	private Label levelLabel;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		backgroundMusic = GetNode<AudioStreamPlayer>("BackgroundMusic");
		backgroundMusic.Stream = GD.Load<AudioStream>("res://Muzika/Foninė_muzika/music_level5_6.mp3");
		backgroundMusic.Play();
		
		levelLabel = GetNodeOrNull<Label>("UI/Panel/InfoLabel");
		
		var global = (GlobalState)GetNode("/root/GlobalState");
		global.currentLevel = 5;
		base._Ready();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
		{
			if (mouseEvent.ButtonIndex == MouseButton.Left || mouseEvent.ButtonIndex == MouseButton.Right)
			{
				//GD.Print(" Mouse button pressed, but doing nothing."); // No action taken
			}
		}
	}
}
