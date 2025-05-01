using Godot;
using System;

public partial class GlobalState : Node
{
	//public int lives = 1;
	//public int maxLives = 5;
	public int lives = 10;
	public int maxLives = 10;
	public int currentLevel = 1;
	public int totalLevels = 12;
	
	public void ResetGameState()
	{
		lives = maxLives;
		currentLevel = 1;
	}
}
