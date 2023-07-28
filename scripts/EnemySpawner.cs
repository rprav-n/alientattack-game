using Godot;
using System;

public class EnemySpawner : Node2D
{

	[Signal]
	private delegate void enemySpawned(Enemy enemy);

	private PackedScene EnemyScene;
	private Node2D spawnPositions;
	private Godot.Collections.Array spawnPosArr;
	private int len;

	public override void _Ready()
	{
		EnemyScene = GD.Load<PackedScene>("res://scenes/Enemy.tscn");
		spawnPositions = GetNode<Node2D>("SpawnPositions");
		spawnPosArr = spawnPositions.GetChildren();
		len = spawnPosArr.Count;
	}
	
	public void _on_SpawnTimer_timeout() 
	{
		var i = (int)GD.RandRange(0, len-1);
		
		Position2D spawnPosition = (Position2D)spawnPosArr[i];
		
		var newEnemy = EnemyScene.Instance<Enemy>();
		newEnemy.GlobalPosition = spawnPosition.Position;
		//AddChild(newEnemy);
		this.EmitSignal("enemySpawned", newEnemy);
	}
}
