using Godot;

public partial class Idle : State
{
	protected Main Main { get; set; }
	protected Timer ShrinkTimer { get; set; }

	public override void _Ready()
	{
		Main = GetParent().GetParent<Main>();
		ShrinkTimer = Main.GetNode<Timer>("ShrinkTimer");
	}

	public override void Enter()
	{
		GD.Print("Main entering Idle state.");
		ShrinkTimer.Stop();
	}
}
