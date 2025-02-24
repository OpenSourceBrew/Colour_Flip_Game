using System;
using Godot;
 
public partial class PagrindinisVeikėjas : CharacterBody2D
{
	public const float Speed = 150.0f;
	public const float JumpVelocity = -400.0f;
 
	private AnimatedSprite2D sprite2d;
 
	public override void _Ready()
	{
		sprite2d = GetNode<AnimatedSprite2D>("Sprite2D");
		GD.Print(sprite2d);
	}
 
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
 
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor()) 
		{
			velocity.Y += gravity * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		float direction = Input.GetAxis("left", "right");
		if (direction != 0)
		{
			velocity.X = direction * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, 12);
		}

		Velocity = velocity;
		MoveAndSlide();

		// Animacijos su tinkamu prioritetu
		if (!IsOnFloor()) 
		{
			sprite2d.Animation = "jumping";
		}
		else if (Math.Abs(velocity.X) > 1) 
		{
			sprite2d.Animation = "walking";
		}
		else 
		{
			sprite2d.Animation = "default";
		}

		// Užtikriname, kad animacija tikrai leidžiama
		sprite2d.Play();

		// Flip the sprite based on the direction.
		sprite2d.FlipH = velocity.X < 0;
	}
}
