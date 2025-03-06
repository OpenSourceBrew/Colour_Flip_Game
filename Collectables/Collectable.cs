using Godot;
using System;

public partial class Collectable : Area2D
{
	private GameManager gameManager;
	private AudioStreamPlayer pickupSound;

	public override void _Ready()
	{
		gameManager = (GameManager)GetTree().Root.GetNode("GameManager");
		pickupSound = GetNode<AudioStreamPlayer>("PickupSound"); // Find the sound player
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
	}

	private void OnBodyEntered(Node body)
	{
		if (body is CharacterBody2D)
		{
			gameManager?.AddPoint();
			
			// Create a separate sound player node before deleting this object
			AudioStreamPlayer tempSound = new AudioStreamPlayer();
			tempSound.Stream = pickupSound.Stream; // Copy the sound
			tempSound.VolumeDb = pickupSound.VolumeDb; // Keep volume
			tempSound.PitchScale = pickupSound.PitchScale; // Keep pitch
			GetTree().Root.AddChild(tempSound); // Add to root so it doesn't get deleted
			tempSound.Play();
			
			// Delete the temporary sound node when finished playing
			tempSound.Finished += () => tempSound.QueueFree();
		}
		QueueFree(); // Immediately remove the collectable
	}
}
