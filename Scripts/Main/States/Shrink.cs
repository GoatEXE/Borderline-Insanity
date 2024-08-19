using Godot;

public partial class Shrink : State
{
	// Nodes
	protected Main Main { get; set; }
	protected Player Player { get; private set; }
	protected Timer ShrinkTimer { get; set; }

	public override void _Ready()
	{
		// Nodes
		Main = GetParent().GetParent<Main>();
		ShrinkTimer = Main.GetNode<Timer>("ShrinkTimer");
		Player = Main.GetNode<Player>("Player");

		// Signals
		ShrinkTimer.Connect("timeout", new Callable(this, "OnReduceScreenTimeout"));
	}
	
	public override void Enter()
	{
		ShrinkTimer.WaitTime = Main.ShrinkRate;
		ShrinkTimer.Start();
	}

	public override void Update(double delta)
	{
		// Clamp player to playable area
		ClampPlayerToPlayableArea();
	}
	
	private void OnReduceScreenTimeout()
	{
		Vector2I currentSize = (Vector2I)Main.WindowSize;
		Vector2I currentPosition = Main.WindowPosition;

		if (currentSize.X != Main.MinimumWindowSize || currentSize.Y != Main.MinimumWindowSize)
		{
			var newSize = new Vector2I(
				x: Mathf.Max(currentSize.X - 2, Main.MinimumWindowSize),
				y: Mathf.Max(currentSize.Y - 2, Main.MinimumWindowSize)
			);

			var newPosition = new Vector2I(
				x: currentPosition.X + 1,
				y: currentPosition.Y + 1
			);

			// Adjust nodes to account for new position
			Vector2I offset = newPosition - currentPosition;            
			RepositionObjects(offset);

			// Set new window size and position
			DisplayServer.WindowSetPosition(newPosition);
			DisplayServer.WindowSetSize(newSize);
		}
	}

	private void RepositionObjects(Vector2I offset)
	{
		foreach (var obj in GetTree().GetNodesInGroup("PlayableArea"))
		{
			if (obj is Node2D node2D)
			{
				node2D.Position -= (Vector2)offset;
			}
		}
	}

	public void ClampPlayerToPlayableArea()
	{
		Player.Position = new Vector2(
			x: Mathf.Clamp(Player.Position.X, Player.HalfSpriteSize, Player.MainScreen.WindowSize.X - Player.HalfSpriteSize),
			y: Mathf.Clamp(Player.Position.Y, Player.HalfSpriteSize, Player.MainScreen.WindowSize.Y - Player.HalfSpriteSize )
		);
	}
}
