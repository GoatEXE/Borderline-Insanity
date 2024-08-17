using Godot;

public partial class Player : Area2D
{
	[Export] public PackedScene BulletScene;
	[Export] public int Speed { get; set; } = 400;
	public int HalfSpriteSize { get; set; } = 33;
	public Main MainScreen { get; set; }

	public override void _Ready()
	{
		Hide();
		AddToGroup("PlayableArea");
		MainScreen = GetParent<Main>();
	}

	public void Start(Vector2 position)
	{
		// Create player in starting position and enable collision

		Position = position;
		Show();
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventMouseButton eventMouseButton && eventMouseButton.Pressed)
		{
			if (eventMouseButton.ButtonIndex == MouseButton.Left)
			{
				SpawnBullet();
			}
		}
	}

	private void SpawnBullet()
	{
		var bullet = (PlayerBullet)BulletScene.Instantiate();
		bullet.GlobalPosition = GlobalPosition;
		GetParent().AddChild(bullet);
	}
}
