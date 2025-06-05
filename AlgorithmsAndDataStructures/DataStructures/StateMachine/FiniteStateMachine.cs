using System;

namespace AlgorithmsAndDataStructures.DataStructures.StateMachine;

public class FiniteStateMachine
{
    private Action currentState;

    public FiniteStateMachine(Action initialState)
    {
        SetState(initialState);
    }

    public void SetState(Action state)
    {
        currentState = state;
    }

    public void Turn()
    {
        currentState?.Invoke();
    }
}