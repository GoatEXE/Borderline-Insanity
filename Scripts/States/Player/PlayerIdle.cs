using Godot;

public partial class PlayerIdle : State
{
	public override void Enter()
	{
		GD.Print("Entering player idle.");
	}

	public override void Exit()
	{
		GD.Print("Exiting player idle.");
	}

	public override void Update(double delta)
	{
		Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");

		if (direction != Vector2.Zero)
		{
			fsm.TransitionTo("PlayerMove");
		}
	}
}
