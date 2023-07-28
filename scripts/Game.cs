using Godot;
using System;

public class Game : Node2D
{

	[Export]
	private int lives = 5;
	
	public int score = 0;
	
	private KinematicBody2D player;
	private HUD hud;

	public override void _Ready()
	{
		player = GetNode<KinematicBody2D>("Player");
		hud = GetNode<HUD>("UI/HUD");
		hud.updateScore(score);
		hud.setLives(lives);
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
		hud.updateLife(lives);
	}
	
	public void _on_EnemySpawner_enemySpawned(Enemy enemy) 
	{
		AddChild(enemy);
		enemy.Connect("died", this, "_on_Enemy_died");
	}
	
	public void _on_Enemy_died() 
	{
		score += 100;
		hud.updateScore(score);
	}
}
