using Godot;

public partial class PlayerMove : State
{
	protected Player Player { get; private set; }

	public override void _Ready()
	{
		Player = GetParent().GetParent<Player>();
	}
	
	public override void Enter()
	{
	 GD.Print("Entering Player Move.");
	}

	public override void Exit()
	{
	 GD.Print("Exiting Player Move.");
	}

	public override void Update(double delta)
	{
		// Movement event handler
		var velocity = new Vector2(
			x: Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left"),
			y: Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up")
		);
		
		if (velocity != Vector2.Zero)
		{
			// Normalize movement if diagonal
			velocity = velocity.Normalized() * Player.Speed;
		}
		else
		{
			// If no movement, transition to Idle state
			fsm.TransitionTo("PlayerIdle");
		}

		// Update position according to velocity
		// 33 is 1/2 sprite width + 1 px
		Player.Position += velocity * (float)delta;
		Player.Position = new Vector2(
			x: Mathf.Clamp(Player.Position.X, Player.HalfSpriteSize, Player.MainScreen.ScreenSize.X - Player.HalfSpriteSize),
			y: Mathf.Clamp(Player.Position.Y, Player.HalfSpriteSize, Player.MainScreen.ScreenSize.Y - Player.HalfSpriteSize )
		);

	}
}
