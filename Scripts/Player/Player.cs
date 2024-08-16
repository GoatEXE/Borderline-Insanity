using Godot;

public partial class Player : Area2D
{
	[Export] public int Speed { get; set; } = 400;
	public int HalfSpriteSize { get; set; } = 33;
	public Main MainScreen { get; set; }

	public override void _Ready()
	{
		Hide();
		MainScreen = GetParent<Main>();
	}

	public void Start(Vector2 position)
	{
		// Create player in starting position and enable collision

		Position = position;
		Show();
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
	}
}
