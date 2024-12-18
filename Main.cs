using Godot;
using System;
using System.Runtime.InteropServices;

public partial class Main : Node
{
	

	[Export]
	public PackedScene pipeScene { get; set; }
    private int counter = 1;
	private Label counterLabel;
	private Vector2 spawnPosition;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		spawnPosition= GetNode<Marker2D>("Marker2D").Position;
        counterLabel = GetNode<Label>("Label");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void OnTimerTimeout(){
		counterLabel.Text= "Poäng: " + counter;
		counter++; 
		//GD.Print("Poäng: " + counter);
		var mypipe= pipeScene.Instantiate<Hinder>();
		mypipe.Position= spawnPosition;
		
		AddChild(mypipe);
	}
	
}
