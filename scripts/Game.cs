using Godot;
using System;

public class Game : Node2D
{

	public override void _Ready()
	{
		
	}
	
	public void _on_DeadZone_area_entered(Area2D area) 
	{
		if (area is Enemy enemy) 
		{
			enemy.QueueFree();
		}
	}
}
