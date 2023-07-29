using Godot;
using System;

public class Game : Node2D
{

	[Export]
	private int lives = 5;
	
	public int score = 0;
	
	private KinematicBody2D player;
	private CanvasLayer ui;
	private HUD hud;

	private PackedScene GameOverScene;
	private AudioStreamPlayer enemyHitSound;
	private AudioStreamPlayer playerHitSound;

	public override void _Ready()
	{
		player = GetNode<KinematicBody2D>("Player");
		ui = GetNode<CanvasLayer>("UI");
		hud = GetNode<HUD>("UI/HUD");
		GameOverScene = ResourceLoader.Load<PackedScene>("res://scenes/GameOver.tscn");
		enemyHitSound = GetNode<AudioStreamPlayer>("EnemyHitSound");
		playerHitSound = GetNode<AudioStreamPlayer>("PlayerHitSound");
		
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
		playerHitSound.Play();
		lives--;
		if (lives == 0)
		{
			player.QueueFree();

			var timer = GetTree().CreateTimer(1.5f);
			timer.Connect("timeout", this, "_show_game_over_screen");
		}
		hud.updateLife(lives);
	}

	public void _show_game_over_screen() 
	{
		var gameOver = GameOverScene.Instance<GameOver>();
		ui.AddChild(gameOver);
		gameOver.setScore(score);	
	}
	
	public void _on_EnemySpawner_enemySpawned(Enemy enemy) 
	{
		AddChild(enemy);
		enemy.Connect("died", this, "_on_Enemy_died");
	}
	
	public void _on_Enemy_died() 
	{
		enemyHitSound.Play();
		score += 100;
		hud.updateScore(score);
	}
}
