using Godot;

public partial class Main : Node2D
{
	[Export] public float ShrinkRate = 0.3f;
	[Export] public int StartingWindowSize { get; set; } = 400;
	[Export] public int MinimumWindowSize { get; set; } = 200;
	public Vector2 WindowSize { get; set; }
	public Vector2I WindowPosition { get; set; }
	public Vector2 DisplaySize { get; set; }

	public override void _Ready()
{
	Player player = GetNode<Player>("Player");

	// Get the screen size of the main display
	Vector2I DisplaySize = DisplayServer.ScreenGetSize(); 

	// Set the initial window size and position
	Vector2I initialSize = new Vector2I(StartingWindowSize, StartingWindowSize);
	Vector2I initialPosition = CalculateInitialPosition(DisplaySize, initialSize);

	DisplayServer.WindowSetSize(initialSize);
	DisplayServer.WindowSetPosition(initialPosition);

	// Create and show the player at the starting position
	Vector2 startPoint = CalculateStartPoint(initialSize);
	player.Start(startPoint);
}

private Vector2I CalculateInitialPosition(Vector2I displaySize, Vector2I initialSize)
{
	return new Vector2I(
		x: (displaySize.X - initialSize.X) / 2,
		y: (displaySize.Y - initialSize.Y) / 2
	);
}

private Vector2 CalculateStartPoint(Vector2I initialSize)
{
	var halfWindowSize = StartingWindowSize / 2;
	return new Vector2(halfWindowSize, halfWindowSize);
}

	public override void _Process(double delta)
	{
		// Update current window size
		WindowSize = GetViewportRect().Size;
		WindowPosition = DisplayServer.WindowGetPosition();
	}

// 	private void ExpandLefSide()
// 	{
// 		// Get the current window size and position
// 		Vector2I currentSize = DisplayServer.WindowGetSize();
// 		Vector2I currentPosition = DisplayServer.WindowGetPosition();

// 		// Calculate the new width with increased left side
// 		int newWidth = currentSize.X + 2; // Increase width by 2 pixels

// 		// Calculate the new position to shift the window to the left
// 		int newPosX = currentPosition.X - 2; // Decrease X position by 2 pixels

// 		// Set the new size and position
// 		// TODO: Move player to compensate for this
// 		DisplayServer.WindowSetSize(new Vector2I(newWidth, currentSize.Y));
// 		DisplayServer.WindowSetPosition(new Vector2I(newPosX, currentPosition.Y));
// 	}

// 	private void ExpandRightSide()
// 	{
// 		// Get the current window size and position
// 		Vector2I currentSize = DisplayServer.WindowGetSize();

// 		// Calculate the new width with increased right side
// 		int newWidth = currentSize.X + 2; // Increase width by 2 pixels

// 		// Set the new size and keep the position unchanged
// 		// TODO: Move player to compensate for this
// 		DisplayServer.WindowSetSize(new Vector2I(newWidth, currentSize.Y));
// 	}

// 	private void ExpandTopSide()
// 	{
// 		// Get the current window size and position
// 		Vector2I currentSize = DisplayServer.WindowGetSize();
// 		Vector2I currentPosition = DisplayServer.WindowGetPosition();

// 		// Calculate the new width with increased top side
// 		int newWidth = currentSize.Y + 2; // Increase height by 2 pixels

// 		// Calculate the new position to shift the window upward
// 		int newPosY = currentPosition.Y - 2; // Decrease Y position by 2 pixels

// 		// Set the new size and keep the position unchanged
// 		// TODO: Move player to compensate for this
// 		DisplayServer.WindowSetSize(new Vector2I(currentSize.X, newWidth));
// 		DisplayServer.WindowSetPosition(new Vector2I(currentPosition.X, newPosY));
// 	}

// 	private void ExpandBottomSide()
// 	{
// 		// Get the current window size and position
// 		Vector2I currentSize = DisplayServer.WindowGetSize();

// 		// Calculate the new height with increased bottom side
// 		int newHeight = currentSize.Y + 2; // Increase height by 2 pixels

// 		// Set the new size and keep the position unchanged 
// 		// TODO: Move player to compensate for this
// 		DisplayServer.WindowSetSize(new Vector2I(currentSize.X, newHeight));
// 	}

}
