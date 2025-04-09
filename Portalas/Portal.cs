using Godot;
using System;

public partial class Portal : Node
{
	private AnimatedSprite2D sprite2D;
	private PackedScene laimejimoLangasScene;

	public override void _Ready()
	{
		sprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		sprite2D.Play("default");

		// Pakraunam sceną iš failo
		laimejimoLangasScene = GD.Load<PackedScene>("res://Interaktyvūs_langai/Laimėjimo_langas/LaimėjimoLangas.tscn");
	}

	private void _on_body_entered(Node2D body)
	{
		if (body.IsInGroup("Player"))
		{
			string currentSceneFile = GetTree().CurrentScene.SceneFilePath;
			string fileName = currentSceneFile.GetFile();
			string levelNumberStr = fileName.Split('_')[0];

			if (int.TryParse(levelNumberStr, out int currentLevelNumber))
			{
				int nextLevelNumber = currentLevelNumber + 1;
				string nextLevelPath = $"res://Lygių_dizainai/{nextLevelNumber}_Lygis.tscn";

				if (ResourceLoader.Exists(nextLevelPath))
				{
					var music = GetTree().CurrentScene.GetNodeOrNull<AudioStreamPlayer>("BackgroundMusic");
					if (music != null && music.GetParent() != GetTree().Root)
					{
						music.GetParent().RemoveChild(music);
						music.Name = "BackgroundMusic";
						GetTree().Root.AddChild(music);
					}

					GetTree().CallDeferred("change_scene_to_file", nextLevelPath);
				}
				else
				{
					ShowWinScreen(); // NEBĖRA DisplayGameCompletedMessage()
				}
			}
			else
			{
				GD.PrintErr($"Nepavyko ištraukti lygio numerio iš: {fileName}");
			}
		}
	}

	private void ShowWinScreen()
	{
		if (laimejimoLangasScene == null)
		{
			GD.PrintErr("Nepavyko įkelti LaimėjimoLangas scenos!");
			return;
		}

		var winWindow = laimejimoLangasScene.Instantiate();

		if (winWindow is LaimėjimoLangas langas)
		{
			GetTree().Root.AddChild(langas);
			langas.Pause(); // Sukuria blur ir pauzuoja žaidimą
		}
		else
		{
			GD.PrintErr("Scena neturi LaimėjimoLangas skripto!");
		}
	}
}
