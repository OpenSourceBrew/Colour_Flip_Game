using Godot;
using System;
using System.IO; // Reikalinga failų tikrinimui

public partial class Portal : Node
{
	private AnimatedSprite2D sprite2D;

	public override void _Ready()
	{
		sprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		sprite2D.Play("default");
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
				
				// Tikriname, ar failas egzistuoja
				if (ResourceLoader.Exists(nextLevelPath))
				{
					GetTree().CallDeferred("change_scene_to_file", nextLevelPath);
				}
				else
				{
					DisplayGameCompletedMessage();
				}
			}
			else
			{
				GD.PrintErr($"Failed to extract level number from file name: {fileName}");
			}
		}
	}

private void DisplayGameCompletedMessage()
{
	// Sukuriame Label ir nustatome tekstą
	Label messageLabel = new Label();
	messageLabel.Text = "SVEIKINAME! TU PERĖJAI ŽAIDIMĄ!";
	messageLabel.AddThemeColorOverride("font_color", new Color(1, 1, 1)); // Balta spalva
	messageLabel.AddThemeFontSizeOverride("font_size", 30); // Šrifto dydis 30

	// Nustatome, kad tekstas būtų kairėje
	messageLabel.HorizontalAlignment = HorizontalAlignment.Left;
	messageLabel.VerticalAlignment = VerticalAlignment.Center;

	// Sukuriame Control konteinerį
	Control container = new Control();

	// Nustatome, kad container būtų centre
	container.AnchorLeft = 0.25f;
	container.AnchorTop = 0.5f;
	container.AnchorRight = 0.5f;
	container.AnchorBottom = 0.5f;

	// Pridedame label į container
	container.AddChild(messageLabel);

	// Sukuriame CanvasLayer, kad elementas būtų rodomas virš kitų objektų
	CanvasLayer canvas = new CanvasLayer();
	canvas.AddChild(container);

	// Pridedame CanvasLayer į pagrindinį medį, kad jis būtų matomas ekrane
	GetTree().Root.AddChild(canvas);
}


}
