using UnityEngine;

public class StateManager : MonoBehaviour
{
	public State currentState;

	private void Update()
	{
		RunStateMachine();
	}

	private void RunStateMachine()
	{
		State nextState = currentState?.RunCurrentState();

		if (nextState != null)
		{
			SwitchToNextState(nextState);
		}

	}

	private void SwitchToNextState(State nextState)
	{
		currentState = nextState;
	}

}
