using Godot;
using System;

public partial class MirtiesLangas : Control
{
	private AnimationPlayer animationPlayer;
	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
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

	private void TestDeath()
	{
		if (!GetTree().Paused)
		{
			Pause();
			GetNode<PauzėsLangas>("../../CanvasLayer/PauzėsLangas").ProcessMode = ProcessModeEnum.Disabled;
			GetNode<PauzėsLangas>("../../CanvasLayer/PauzėsLangas").MouseFilter = MouseFilterEnum.Ignore;
		}
	}


	private void _on_pradeti_is_naujo_pressed()
	{
		Resume();
		GetTree().ReloadCurrentScene();
	}

	private void _on_grizti_i_meniu_pressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile("res://Interaktyvūs_langai/Pradžios_langas/pradžios_langas.tscn");
	}

	public override void _Process(double delta)
	{
		
	}
}
