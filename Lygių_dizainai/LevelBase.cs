using Godot;
using System;

public partial class LevelBase : Node
{
	protected Label levelLabel;
	protected int totalLevels = 12;
	
	public override void _Ready()
	{
		levelLabel = GetNodeOrNull<Label>("UI/Panel/InfoLabel");
		UpdateInfoLabel();
	}
	
	public void UpdateInfoLabel()
	{
		var global = (GlobalState)GetNode("/root/GlobalState");
		
		string gyvybesText = (global.lives % 1 == 0)
		? $"{(int)global.lives}"               // sveikas skaičius → be kablelio
		: $"{global.lives:F1}";               // ne sveikas → su vienu skaičiumi po kablelio
		
		string maxGyvybesText = (global.maxLives % 1 == 0)
		? $"{(int)global.maxLives}"
		: $"{global.maxLives:F1}";
		if (levelLabel != null)
		{
			levelLabel.Text = $"Žaidimo lygis: {global.currentLevel} / {global.totalLevels}\n" +
							  $"Gyvybės: {gyvybesText} / {maxGyvybesText}";
							  //$"Gyvybės: {global.lives} / {global.maxLives}";
		}
	}
	public void AddPoints(int value)
	{
		var global = (GlobalState)GetNode("/root/GlobalState");
		global.lives += value;
		UpdateInfoLabel();
	}
	public void DecreaseLives(int value)
	{
		var global = (GlobalState)GetNode("/root/GlobalState");
		global.lives -= value;
		if (global.lives < 0) global.lives = 0;
		UpdateInfoLabel();
		////if (global.lives == 0)
		////{
			////GD.Print("Game Over!");
			////// Čia gali restartuoti lygį arba grąžinti į meniu
		////}
	}
}
