using Godot;
using System;

public class EnemySpawner : Node2D
{

	public override void _Ready()
	{
		
	}

	public override void _Process(float delta)
	{
		
	}
	
	public void _on_SpawnTimer_timeout() 
	{
		GD.Print("Timeout");
	}
}
