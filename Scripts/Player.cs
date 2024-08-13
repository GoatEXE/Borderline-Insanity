using Godot;

public partial class Player : Area2D
{
	[Export] public int Speed { get; set; } = 400;
	public int HalfSpriteSize { get; set; } = 33;
	private Vector2 _screenSize;

	public override void _Ready()
	{
		Hide();
	}

	public override void _Process(double delta)
	{
		// Update current screen size
		Vector2 _screenSize = GetViewportRect().Size;

		// Movement event handler
		var velocity = new Vector2(
			x: Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left"),
			y: Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up")
		);
		
		// Account for diagnal move speed if moving
		if (velocity != Vector2.Zero)
		{
			velocity = velocity.Normalized() * Speed;
		}		

		// Update position according to velocity
		// 33 is 1/2 sprite width + 1 px
		Position += velocity * (float)delta;
		Position = new Vector2(
			x: Mathf.Clamp(Position.X, HalfSpriteSize, _screenSize.X - HalfSpriteSize),
			y: Mathf.Clamp(Position.Y, HalfSpriteSize, _screenSize.Y - HalfSpriteSize )
		);

	}


	// Create player in starting position and enable collision
	public void Start(Vector2 position)
	{
		Position = position;
		Show();
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
	}
}
