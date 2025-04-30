using Godot;
using System;

public partial class MovingBlock : Node2D
{
	[Export] public Vector2 Direction = Vector2.Right;
	[Export] public float Speed = 100f;
	[Export] public float MaxDistance = 200f;

	private Vector2 _startPosition;
	private float _traveled = 0f;

	public override void _Ready()
	{
		_startPosition = Position;
		Direction = Direction.Normalized();
	}

	public override void _Process(double delta)
	{
		float moveAmount = Speed * (float)delta;
		Position += Direction * moveAmount;
		_traveled += moveAmount;

		if (_traveled >= MaxDistance)
		{
			Direction *= -1;
			_traveled = 0f;
		}
	}
}
