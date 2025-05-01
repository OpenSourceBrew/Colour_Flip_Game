using Godot;
using System;

public partial class MirtiesLangas : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void _on_pradeti_is_naujo_pressed()
	{
		var global = (GlobalState)GetNode("/root/GlobalState");
		global.ResetGameState();
		
		GetTree().ChangeSceneToFile("res://Lygių_dizainai/1_Lygis.tscn");
	}
	
	private void _on_grizti_i_meniu_pressed()
	{
		var global = (GlobalState)GetNode("/root/GlobalState");
		global.ResetGameState();
		
		GetTree().ChangeSceneToFile("res://Interaktyvūs_langai/Pradžios_langas/pradžios_langas.tscn");
	}
}
