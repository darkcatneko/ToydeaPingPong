using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager 
{
    public StateBase CurrentState;

    private Dictionary<State_Enum, StateBase> status_ = new Dictionary<State_Enum, StateBase>();
    /// <summary>
    /// switch State
    /// </summary>
    public void TransitionState(State_Enum type)
    {
        if (CurrentState != null)
        {
            CurrentState.OnExit();
        }
        CurrentState = status_[type];
        CurrentState.OnEnter();
    }
    public void StageManagerInit()
    {
        status_.Add(State_Enum.Waiting_State, new WaitingState(this));
        status_.Add(State_Enum.Launch_State, new LaunchState(this));
        status_.Add(State_Enum.Race_State, new RaceState(this));

        TransitionState(State_Enum.Waiting_State);
    }
    public void StageManagerUpdate()
    {
        CurrentState.OnUpdate();
    }
}
