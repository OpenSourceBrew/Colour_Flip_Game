using Godot;
using System;

public partial class PauzėsLangas : Control
{
	private AnimationPlayer animationPlayer;

	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer1");
		if (animationPlayer != null)
		{
			animationPlayer.Play("RESET");
		}
	}

	public void Resume()
	{
		if (!GetTree().Paused)
			return; // Jei jau atnaujinta, nieko nedarome
			
		GetTree().Paused = false;

		if (animationPlayer != null)
		{
			animationPlayer.PlayBackwards("blur");
		}
		else
		{
			GD.Print("Warning: AnimationPlayer not found!");
		}
	}

	public void Pause()
	{
		GetTree().Paused = true;
		if (animationPlayer != null)
		{
			animationPlayer.Play("blur");
		}
	}

	private void TestEsc()
	{
		if (Input.IsActionJustPressed("esc") && !GetTree().Paused)
		{
			Pause();
		}
		else if (Input.IsActionJustPressed("esc") && GetTree().Paused)
		{
			Resume();
		}
	}

	private void _on_testi_pressed()
	{
		Resume();
	}

	private void _on_pradeti_is_naujo_pressed()
	{
		var global = (GlobalState)GetNode("/root/GlobalState");
		global.ResetGameState();
		
		Resume();
		GetTree().ReloadCurrentScene();
	}

	private void _on_grizti_i_meniu_pressed()
	{
		var global = (GlobalState)GetNode("/root/GlobalState");
		global.ResetGameState();
		
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile("res://Interaktyvūs_langai/Pradžios_langas/pradžios_langas.tscn");
	}

	public override void _Process(double delta)
	{
		TestEsc();
	}
}
