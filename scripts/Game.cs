using Godot;
using System;

public class Game : Node2D
{

	[Export]
	private int lives = 3;
	
	private KinematicBody2D player;

	public override void _Ready()
	{
		player = GetNode<KinematicBody2D>("Player");
	}
	
	public void _on_DeadZone_area_entered(Area2D area) 
	{
		if (area is Enemy enemy) 
		{
			enemy.QueueFree();
		}
	}
	
	public void _on_Player_tookDamage() 
	{
		lives--;
		if (lives == 0) 
		{
			GD.Print("Game Over");
			player.QueueFree();
		}
	}
}
