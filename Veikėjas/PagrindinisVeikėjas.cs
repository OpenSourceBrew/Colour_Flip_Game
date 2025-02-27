using Godot;
using System;

public partial class PagrindinisVeikėjas : CharacterBody2D
{
	private const float SPEED = 150.0f;
	private const float JUMP_VELOCITY = -600.0f;
	private int gravity = 2500;
	private int gravityDirection = 1;
	private const float FRICTION = 1000.0f;

	private AnimatedSprite2D sprite2D;

	public override void _Ready()
	{
		sprite2D = GetNode<AnimatedSprite2D>("Sprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		// Apply gravity
		if (!IsOnFloor() && gravityDirection == 1)
		Velocity = new Vector2(Velocity.X, Velocity.Y + gravity * (float)delta);
		else if (!IsOnCeiling() && gravityDirection == -1)
		Velocity = new Vector2(Velocity.X, Velocity.Y - gravity * (float)delta);
		
		// Jumping
		if (Input.IsActionJustPressed("jump") && 
		((gravityDirection == 1 && IsOnFloor()) || (gravityDirection == -1 && IsOnCeiling())))
		{
			Velocity = new Vector2(Velocity.X, JUMP_VELOCITY * gravityDirection);
		}
		
		// Gravity Change
		if (Input.IsActionJustPressed("gravityChange"))
		{
			gravityDirection *= -1;
			sprite2D.FlipV = (gravityDirection == -1);
		}
			
		// Movement with Friction
		float direction = Input.GetAxis("left", "right");
		if (direction != 0)
			Velocity = new Vector2(direction * SPEED, Velocity.Y);
		else
			Velocity = new Vector2(Mathf.MoveToward(Velocity.X, 0, FRICTION * (float)delta), Velocity.Y);

		// **Call MoveAndSlide() Correctly**
		MoveAndSlide();
		
		sprite2D.FlipH = Velocity.X < 0;
		
		// **Corrected Animation Handling**
		if (!IsOnFloor()) // Character is in the air
		{
			sprite2D.Play("jumping");
		}
		else if (Math.Abs(Velocity.X) > 1) // Character is running
		{
			sprite2D.Play("walking");
		}
		else // Character is idle
		{
			sprite2D.Play("default");
		}
	}
}
