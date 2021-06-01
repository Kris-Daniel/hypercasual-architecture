namespace Systems.FSM
{
	public interface IState
	{
		void Tick();
		void OnEnter();
		void OnExit();
	}
}