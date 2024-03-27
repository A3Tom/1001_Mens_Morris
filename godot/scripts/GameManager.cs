using Godot;
using NMM_Logic.Classes;
using System;

public partial class GameManager : Node
{
	[Export] float minMoveDelay;
	[Export] NodePath boardUIPath;
	[Export] NodePath humanPlayerPath;
	
	[Export] Button resignButton;
	[Export] Button newMatchButton;

	private HumanPlayer humanPlayer;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		humanPlayer = GetNode<HumanPlayer>(humanPlayerPath);
		humanPlayer.MoveChosen += OnMoveChosen;

		resignButton.Pressed += ResignGame;
		newMatchButton.Pressed += NewGame;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnMoveChosen(Move move)
	{

	}

	private void NewGame()
	{

	}

	private void ResignGame()
	{

	}
}
