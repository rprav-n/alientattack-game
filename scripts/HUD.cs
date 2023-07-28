using Godot;
using System;

public class HUD : Control
{
	private Label scoreLabel;
	private TextureRect life;

	public override void _Ready()
	{
		scoreLabel = GetNode<Label>("ScoreLabel");
		life = GetNode<TextureRect>("LifesTextureRect");
	}
	
	public void updateScore(int score) 
	{
		scoreLabel.Text = "Score: " + score.ToString();
	}
	
	public void updateLife(int lives) 
	{
		GD.Print("lives", lives);
		if (lives == 0) 
		{
			life.Visible = false;
		} else 
		{
			var newRectSize = new Vector2(126, 0);
			life.RectSize -= newRectSize;
		}
		
	}
	
	public void setLives(int lives) 
	{
		var newRectSize = new Vector2(126 * lives, 0);
		life.RectSize = newRectSize;	
	}

}
