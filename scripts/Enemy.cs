using Godot;
using System;

public class Enemy : Area2D
{
	[Export]
	private int speed = 200;

	public override void _Ready()
	{
		
	}

	public override void _PhysicsProcess(float delta)
	{
		var newPosition = new Vector2(-1 * speed * delta, 0);
		
		this.GlobalPosition += newPosition;
	}
		
	public void Died() 
	{
		QueueFree();
	}
	
	public void _on_Enemy_body_entered(Node node) 
	{
		if (node is Player player) 
		{
			player.takeDamage();
			Died();
		}
	}
}
