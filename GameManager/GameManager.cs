using Godot;
using System;

public partial class GameManager : Node
{
	private Label pointsLabel;
	private int score = 0;
	
	public override void _Ready()
	{
		pointsLabel = GetNodeOrNull<Label>("/root/Node2/UI/Panel/PointsLabel");
	}
	public void AddPoint()
	{
		score++;
		//GD.Print("Score: " + score);
		if (pointsLabel != null)
		{
			pointsLabel.Text = "Points: " + score.ToString();
		}
	}
}
