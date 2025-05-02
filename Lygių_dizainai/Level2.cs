using Godot;
using System;

public partial class Level2 : LevelBase
{
	private Label levelLabel;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var music = GetTree().Root.GetNodeOrNull<AudioStreamPlayer>("BackgroundMusic");
		if (music != null && !music.Playing)
		{
			music.Play();
		}
		
		levelLabel = GetNodeOrNull<Label>("UI/Panel/InfoLabel");
		
		var global = (GlobalState)GetNode("/root/GlobalState");
		global.currentLevel = 2;
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
				//GD.Print(" Mouse button pressed, but doing nothing."); //  No action taken
			}
		}
	}
}
