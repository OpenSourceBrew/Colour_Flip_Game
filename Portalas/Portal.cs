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
					// PERKELIAME MUZIKĄ
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
		
		// Sustabdome žaidimą
		GetTree().Paused = true;
		
		// CanvasLayer – virš visko
		CanvasLayer canvas = new CanvasLayer();
		canvas.ProcessMode = Node.ProcessModeEnum.Always;

		// Panel – permatoma fono dėžutė aplink turinį
		Panel panel = new Panel();
		panel.AnchorLeft = 0.2f;
		panel.AnchorRight = 0.8f;
		panel.AnchorTop = 0.2f;
		panel.AnchorBottom = 0.8f;
		panel.OffsetLeft = 0;
		panel.OffsetTop = 0;
		panel.OffsetRight = 0;
		panel.OffsetBottom = 0;
		panel.SizeFlagsHorizontal = Control.SizeFlags.ExpandFill;
		panel.SizeFlagsVertical = Control.SizeFlags.ExpandFill;
		panel.ProcessMode = Node.ProcessModeEnum.Always;

		// Uždedame stilių (permatoma fono spalva ir užapvalinti kampai)
		var style = new StyleBoxFlat
		{
			BgColor = new Color(0, 0, 0, 0.6f), // Juoda su 60% permatomumu
			CornerRadiusTopLeft = 20,
			CornerRadiusTopRight = 20,
			CornerRadiusBottomLeft = 20,
			CornerRadiusBottomRight = 20,
			ContentMarginLeft = 20,
			ContentMarginRight = 20,
			ContentMarginTop = 20,
			ContentMarginBottom = 20

		};
		panel.AddThemeStyleboxOverride("panel", style);

		// VBoxContainer – turinys viduje
		VBoxContainer vbox = new VBoxContainer();
		vbox.SizeFlagsHorizontal = Control.SizeFlags.ExpandFill;
		vbox.SizeFlagsVertical = Control.SizeFlags.ExpandFill;
		vbox.Alignment = BoxContainer.AlignmentMode.End;
		vbox.AddThemeConstantOverride("separation", 20);

		// Sveikinimo tekstas
		Label messageLabel = new Label();
		messageLabel.Text = "SVEIKINAME! TU PERĖJAI ŽAIDIMĄ!";
		messageLabel.AddThemeColorOverride("font_color", new Color(1, 1, 1));
		messageLabel.AddThemeFontSizeOverride("font_size", 30);
		messageLabel.HorizontalAlignment = HorizontalAlignment.Center;
		messageLabel.HorizontalAlignment = HorizontalAlignment.Center;
		// Grįžti į meniu
		Button returnButton = new Button();
		returnButton.Text = "Grįžti į pagrindinį meniu";
		returnButton.AddThemeFontSizeOverride("font_size", 24);
		returnButton.SizeFlagsHorizontal = Control.SizeFlags.ShrinkCenter;

		// Išeiti
		Button quitButton = new Button();
		quitButton.Text = "Išeiti iš žaidimo";
		quitButton.AddThemeFontSizeOverride("font_size", 24);
		quitButton.SizeFlagsHorizontal = Control.SizeFlags.ShrinkCenter;

		// Sudedame
		vbox.AddChild(messageLabel);
		vbox.AddChild(returnButton);
		vbox.AddChild(quitButton);

		panel.AddChild(vbox);     // VBox į Panel
		canvas.AddChild(panel);   // Panel į CanvasLayer
		GetTree().Root.AddChild(canvas); // CanvasLayer į sceną

		// Mygtukų veiksmai
		returnButton.Pressed += () =>
		{
			canvas.QueueFree();
			GetTree().Paused = false;
			GetTree().ChangeSceneToFile("res://Interaktyvūs_langai/Pradžios_langas/pradžios_langas.tscn");
		};

		quitButton.Pressed += () =>
		{
			GetTree().Quit();
		};
	}

//private void DisplayGameCompletedMessage()
//{
	//// Sukuriame Label ir nustatome tekstą
	//Label messageLabel = new Label();
	//messageLabel.Text = "SVEIKINAME! TU PERĖJAI ŽAIDIMĄ!";
	//messageLabel.AddThemeColorOverride("font_color", new Color(1, 1, 1)); // Balta spalva
	//messageLabel.AddThemeFontSizeOverride("font_size", 30); // Šrifto dydis 30
//
	//// Nustatome, kad tekstas būtų kairėje
	//messageLabel.HorizontalAlignment = HorizontalAlignment.Left;
	//messageLabel.VerticalAlignment = VerticalAlignment.Center;
//
	//// Sukuriame Control konteinerį
	//Control container = new Control();
//
	//// Nustatome, kad container būtų centre
	//container.AnchorLeft = 0.25f;
	//container.AnchorTop = 0.5f;
	//container.AnchorRight = 0.5f;
	//container.AnchorBottom = 0.5f;
//
	//// Pridedame label į container
	//container.AddChild(messageLabel);
//
	//// Sukuriame CanvasLayer, kad elementas būtų rodomas virš kitų objektų
	//CanvasLayer canvas = new CanvasLayer();
	//canvas.AddChild(container);
//
	//// Pridedame CanvasLayer į pagrindinį medį, kad jis būtų matomas ekrane
	//GetTree().Root.AddChild(canvas);
//}


}
