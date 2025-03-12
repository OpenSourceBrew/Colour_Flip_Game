using Godot;
using System;

public partial class PradžiosLangas : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

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
		
	}
	
	public void _on_iseiti_pressed()
	{
		GetTree().Quit();
	}
	
	
}
