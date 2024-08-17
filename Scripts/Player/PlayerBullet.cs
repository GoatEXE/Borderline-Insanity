using Godot;

public partial class PlayerBullet : Area2D
{
	[Export] public int Speed = 800;

	private Vector2 _direction;

	public override void _Ready()
	{
		// Position can be adjusted during window shrink
		AddToGroup("PlayableArea");

		// Where's the mouse at?
		Vector2 targetPosition = GetGlobalMousePosition();

		// Calculate the direction to the mouse
		_direction = (targetPosition - GlobalPosition).Normalized();  
	}

	public override void _PhysicsProcess(double delta)
	{
		// Move the bullet in the direction calculated
		Vector2 velocity = _direction * Speed * (float)delta;
		GlobalPosition += velocity;

		// Check if the bullet is outside the screen
		if (!IsOnScreen())
		{
			QueueFree();
		}
	}

	private bool IsOnScreen()
	{
		// Get the screen bounds
		Rect2 screenRect = new Rect2(Vector2.Zero, GetViewportRect().Size);

		// Check if the bullet is within the screen bounds
		return screenRect.HasPoint(GlobalPosition);
	}
}
