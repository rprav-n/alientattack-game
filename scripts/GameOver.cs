using Godot;
using System;

public class GameOver : Control
{

	private Label scoreLabel;

	public override void _Ready()
	{
		scoreLabel = GetNode<Label>("Panel/ScoreLabel");
	}
	
	public void setScore(int score) 
	{
		scoreLabel.Text = "Score: " + score.ToString();
	}

	public void _on_RetryButton_pressed() 
	{
		GetTree().ReloadCurrentScene();
		
	}
}


