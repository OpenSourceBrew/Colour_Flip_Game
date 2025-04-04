using Godot;
using System;

public partial class Collectable : Area2D
{
	private AudioStreamPlayer pickupSound;
	[Export] public float livesValue = 0.5f;
	
	public override void _Ready()
	{
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
		pickupSound = GetNode<AudioStreamPlayer>("PickupSound");
	}

	private void OnBodyEntered(Node body)
	{
		if (body is CharacterBody2D)
		{
			if (GetTree().CurrentScene is LevelBase level)
			{
				level.AddPoints(livesValue);
			}
			QueueFree();
			
			//Create a separate sound player node before deleting this object
			AudioStreamPlayer tempSound = new AudioStreamPlayer();
			tempSound.Stream = pickupSound.Stream; // Copy the sound
			tempSound.VolumeDb = pickupSound.VolumeDb; // Keep volume
			tempSound.PitchScale = pickupSound.PitchScale; // Keep pitch
			GetTree().Root.AddChild(tempSound); // Add to root so it doesn't get deleted
			tempSound.Play();
			
			// Delete the temporary sound node when finished playing
			tempSound.Finished += () => tempSound.QueueFree();
		}
	}
}
