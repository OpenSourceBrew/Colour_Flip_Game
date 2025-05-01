using Godot;
using System;

public partial class DeadlyBlock : Area2D
{
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
			if (global.lives < 0)
				global.lives = 0;

			// ----->>>>>> Čia pridedame UI atnaujinimą
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
				GetTree().ChangeSceneToFile("res://Interaktyvūs_langai/Mirties_langas/Mirties_Langas.tscn");
			}
		}
	}
}
