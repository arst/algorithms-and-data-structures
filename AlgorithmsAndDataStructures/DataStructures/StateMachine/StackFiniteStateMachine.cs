using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures.StateMachine;

// This type of FSM is usefull for tracking previous state if you can return to different state from the current one,
// so backward transition is not straightforward.
// Important note: It's state who is reposnsible for poping itself from the stack and push next state onto the stack
public class StackFiniteStateMachine
{
    private readonly Stack<Action> stack = new();

    public void Turn()
    {
        GetCurrentState()?.Invoke();
    }

    public void PushState(Action state)
    {
        stack.Push(state);
    }

    private Action GetCurrentState()
    {
        return stack.Count > 0 ? stack.Peek() : null;
    }

    public Action PopState()
    {
        var state = stack.Count > 0 ? stack.Pop() : null;
        return state;
    }
}