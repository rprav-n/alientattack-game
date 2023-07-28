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
	
	public void _on_VisibleNotifier_screen_exited() 
	{
		QueueFree();
	}
	
	public void _on_Rocket_area_entered(Area2D area) 
	{
		if (area is Enemy enemy) 
		{
			enemy.Died();
			
			// Remove the rocket
			QueueFree();
		}
	}
	
}
