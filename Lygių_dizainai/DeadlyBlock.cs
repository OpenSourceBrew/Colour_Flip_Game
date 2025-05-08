using Godot;
using System;

public partial class DeadlyBlock : Area2D
{
	private AudioStreamPlayer deathAudio;
	public override void _Ready()
	{
		Connect("body_entered", new Callable(this, nameof(_on_deadly_block_body_entered)));
		
	}

	private void _on_deadly_block_body_entered(Node body)
	{
		if (body is PagrindinisVeikėjas player)
		{
			var global = (GlobalState)GetNode("/root/GlobalState");
			global.lives -= 1;
			
			deathAudio = GetNode<AudioStreamPlayer>("DeathAudio");
			deathAudio.Stream = GD.Load<AudioStream>("res://Muzika/Garso_efektai/hit01.wav");
			deathAudio.VolumeDb = -6;
			deathAudio.Play();
			
			if (global.lives < 0)
			{
				global.lives = 0;
			}
			
			// Čia pridedame UI atnaujinimą
			var levelBase = GetTree().CurrentScene as LevelBase;
			if (levelBase != null)
			{
				levelBase.UpdateInfoLabel();
			}

			// Rasti respawn point SAUGIAI
			var respawnPoint = GetTree().CurrentScene.FindChild("RespawnPoint", true, false) as Node2D;
			if (respawnPoint != null)
			{
				player.RespawnAt(respawnPoint.GlobalPosition);
			}
			else
			{
				GD.PrintErr("RespawnPoint nerastas!");
			}

			// Jei gyvybių nebeliko — galima daryti Game Over langą
			if (global.lives <= 0)
			{
				CallDeferred(nameof(KeistiScena));
			}
		}
	}
	private void KeistiScena()
	{
		GetTree().ChangeSceneToFile("res://Interaktyvūs_langai/Mirties_langas/mirties_langas.tscn");
	}
}
