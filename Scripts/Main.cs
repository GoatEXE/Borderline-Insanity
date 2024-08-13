using Godot;
using System;

public partial class Main : Node2D
{

	[Export] public int StartingWindowSize { get; set; } = 400;
	[Export] public int MinimumWindowSize { get; set; } = 200;

	public override void _Ready()
	{
		Player player = GetNode<Player>("Player");

		// Get the screen size of the main display
		Vector2I screenSize = DisplayServer.ScreenGetSize(); 

		// Set the initial window size
		Vector2I initialSize = new Vector2I(StartingWindowSize, StartingWindowSize);
		DisplayServer.WindowSetSize(initialSize);

		// Find the center of the window
		var halfWindowSize = StartingWindowSize / 2;
		Vector2 startPoint = new Vector2(halfWindowSize, halfWindowSize);

		// Find the center of the screen
		int posX = (screenSize.X - initialSize.X) / 2;
		int posY = (screenSize.Y - initialSize.Y) / 2;

		// Set the initial Window position on main display
		Vector2I initialPosition = new Vector2I(posX, posY);
		DisplayServer.WindowSetPosition(initialPosition);

		// Create show player at starting position
		player.Start(startPoint);
	}

	private void ExpandLefSide()
	{
		// Get the current window size and position
		Vector2I currentSize = DisplayServer.WindowGetSize();
		Vector2I currentPosition = DisplayServer.WindowGetPosition();

		// Calculate the new width with increased left side
		int newWidth = currentSize.X + 2; // Increase width by 2 pixels

		// Calculate the new position to shift the window to the left
		int newPosX = currentPosition.X - 2; // Decrease X position by 2 pixels

		// Set the new size and position
		// TODO: Move player to compensate for this
		DisplayServer.WindowSetSize(new Vector2I(newWidth, currentSize.Y));
		DisplayServer.WindowSetPosition(new Vector2I(newPosX, currentPosition.Y));
	}

	private void ExpandRightSide()
	{
		// Get the current window size and position
		Vector2I currentSize = DisplayServer.WindowGetSize();

		// Calculate the new width with increased right side
		int newWidth = currentSize.X + 2; // Increase width by 2 pixels

		// Set the new size and keep the position unchanged
		// TODO: Move player to compensate for this
		DisplayServer.WindowSetSize(new Vector2I(newWidth, currentSize.Y));
	}

	private void ExpandTopSide()
	{
		// Get the current window size and position
		Vector2I currentSize = DisplayServer.WindowGetSize();
		Vector2I currentPosition = DisplayServer.WindowGetPosition();

		// Calculate the new width with increased top side
		int newWidth = currentSize.Y + 2; // Increase height by 2 pixels

		// Calculate the new position to shift the window upward
		int newPosY = currentPosition.Y - 2; // Decrease Y position by 2 pixels

		// Set the new size and keep the position unchanged
		// TODO: Move player to compensate for this
		DisplayServer.WindowSetSize(new Vector2I(currentSize.X, newWidth));
		DisplayServer.WindowSetPosition(new Vector2I(currentPosition.X, newPosY));
	}

	private void ExpandBottomSide()
	{
		// Get the current window size and position
		Vector2I currentSize = DisplayServer.WindowGetSize();

		// Calculate the new height with increased bottom side
		int newHeight = currentSize.Y + 2; // Increase height by 2 pixels

		// Set the new size and keep the position unchanged 
		// TODO: Move player to compensate for this
		DisplayServer.WindowSetSize(new Vector2I(currentSize.X, newHeight));
	}

}
