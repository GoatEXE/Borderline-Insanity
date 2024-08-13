using Godot;

public partial class Shrink : State
{
	// Nodes
	protected Main Main { get; set; }
	protected Timer ShrinkTimer { get; set; }

	public override void _Ready()
	{
		// Nodes
		Main = GetParent().GetParent<Main>();
		ShrinkTimer = Main.GetNode<Timer>("ShrinkTimer");

		// Signals
		ShrinkTimer.Connect("timeout", new Callable(this, "OnReduceScreenTimeout"));
	}
	
	public override void Enter()
	{
		ShrinkTimer.Start();
	}

	private void OnReduceScreenTimeout()
	{
		// Get the current window size and position
		Vector2I currentSize = DisplayServer.WindowGetSize();
		Vector2I currentPosition = DisplayServer.WindowGetPosition();

		// TODO: Make these comparisons separately
		if (currentSize.X != Main.MinimumWindowSize || currentSize.Y != Main.MinimumWindowSize){
			// Calculate the new size with decreased width and height
			int newWidth = Mathf.Max(currentSize.X - 2, Main.MinimumWindowSize); // Decrease width by 2 pixels
			int newHeight = Mathf.Max(currentSize.Y - 2, Main.MinimumWindowSize); // Decrease height by 2 pixels

			// Calculate the new position to maintain the centered effect
			int newPosX = currentPosition.X + 1; // Move window slightly to the right
			int newPosY = currentPosition.Y + 1; // Move window slightly down

			// TODO: Move player to compensate for this
			// Set the new window position and size
			DisplayServer.WindowSetPosition(new Vector2I(newPosX, newPosY));
			DisplayServer.WindowSetSize(new Vector2I(newWidth, newHeight));
		}
	}
}
