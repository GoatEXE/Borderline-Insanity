using Godot;

public partial class Idle : State
{
	// Nodes
	protected Main Main { get; set; }
	protected Player Player { get; private set; }
	protected Timer ShrinkTimer { get; set; }

	public override void _Ready()
	{
		Main = GetParent().GetParent<Main>();
		Player = Main.GetNode<Player>("Player");
		ShrinkTimer = Main.GetNode<Timer>("ShrinkTimer");
	}

	public override void Enter()
	{
		GD.Print("Main entering Idle state.");
		ShrinkTimer.Stop();
	}

	public override void Exit()
	{
		GD.Print("Main exiting Idle state.");
	}

	public override void Update(double delta)
	{
		// Clamp player to playable area
		ClampPlayerToPlayableArea();
	}

	public void ClampPlayerToPlayableArea()
	{
		Player.Position = new Vector2(
			x: Mathf.Clamp(Player.Position.X, Player.HalfSpriteSize, Player.MainScreen.WindowSize.X - Player.HalfSpriteSize),
			y: Mathf.Clamp(Player.Position.Y, Player.HalfSpriteSize, Player.MainScreen.WindowSize.Y - Player.HalfSpriteSize )
		);
	}
}
