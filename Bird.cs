using Godot;
using System;

public partial class Bird : CharacterBody2D
{

	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

     public float gravity = ProjectSettings.GetSetting ("physics/2d/default_gravity").AsSingle();

    public override void _Ready()
	{
		GD.Print(gravity);
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Handle Jump.
		if (Input.IsActionJustPressed("jump"))
		{
			velocity.Y = JumpVelocity;
			
		}
		velocity.Y +=gravity * (float)delta;
		Velocity = velocity;
		MoveAndSlide();
	}

   public void OnArea2DAreaEntered(Node2D area){  //Dör fågeln
	GD.Print(area.Name);
	if (area.Name != "Bird"){
			GetTree().Quit();
	}
    
   }
}
