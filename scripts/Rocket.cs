using Godot;
using System;

public class Rocket : Area2D
{

	[Export]
	private int speed = 200;

	public override void _Ready()
	{
		base._Ready();        
	}

	public override void _PhysicsProcess(float delta)
	{
		var newPosition = Vector2.Zero;
		
		newPosition.x += speed * delta;
		
		this.GlobalPosition += newPosition;
	}
}
