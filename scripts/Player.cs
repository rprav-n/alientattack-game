using Godot;
using System;

public class Player : KinematicBody2D
{

	[Export]
	private int speed = 200;
	
	
	public override void _Ready()
	{
		base._Ready();
	}

	public override void _PhysicsProcess(float delta)
	{
		base._PhysicsProcess(delta);
		
		var newVelocity = Vector2.Zero;

		newVelocity.x = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
		newVelocity.y = Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up");
		
		newVelocity = newVelocity.Normalized();
		
		newVelocity *= speed;
		
		MoveAndSlide(newVelocity);
		
		var newPosition = this.GlobalPosition;
		
		var screenSize = GetViewportRect().Size;
		
		/* if (this.GlobalPosition.x < 0)
			newPosition.x = 0;
		if (this.GlobalPosition.x > screenSize.x)
			newPosition.x = screenSize.x;
		if (this.GlobalPosition.y < 0)
			newPosition.y = 0;
		if (this.GlobalPosition.y > screenSize.y)
			newPosition.y = screenSize.y; */
		
		newPosition.x = Mathf.Clamp(this.GlobalPosition.x, 0, screenSize.x);
		newPosition.y = Mathf.Clamp(this.GlobalPosition.y, 0, screenSize.y);
		
		
		this.GlobalPosition = newPosition;
	}
}
