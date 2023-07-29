using Godot;
using System;

public class PathEnemy : Path2D
{
	private PathFollow2D pathFollow;
	private Enemy enemy;

	public override void _Ready()
	{
		pathFollow = GetNode<PathFollow2D>("PathFollow2D");
		enemy = GetNode<Enemy>("PathFollow2D/Enemy");
		
		pathFollow.UnitOffset = 1;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		pathFollow.UnitOffset -= 0.25f * delta;
		if (pathFollow.UnitOffset <= 0) 
		{
			QueueFree();
		}
	}
}
