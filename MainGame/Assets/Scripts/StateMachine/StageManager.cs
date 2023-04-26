using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class StageManager 
{
    public StateBase CurrentState;
    /// <summary>
    /// switch State
    /// </summary>
    public void TransitionState(State_Enum type, StageData stageData)
    {
        if (CurrentState != null)
        {
            CurrentState.OnExit();
        }

        changeAndNewState(type,stageData);


        CurrentState.OnEnter();

        

    }
    public void TransitionState(State_Enum type)
    {
        var stagedata = new StageData();
        if (CurrentState != null)
        {
            CurrentState.OnExit();
        }

        changeAndNewState(type, stagedata);


        CurrentState.OnEnter();



    }


    private void changeAndNewState(State_Enum type, StageData stageData)
    {
        switch (type)
        {
            case State_Enum.Waiting_State:
                CurrentState = new WaitingState(this);
                return;
            case State_Enum.Launch_State:
                CurrentState = new LaunchState(this);
                return;
            case State_Enum.Race_State:
                CurrentState = new RaceState(this, stageData.RepeatableRaceType);
                return;
            case State_Enum.Training_State:
                CurrentState = new TrainingState(this);
                return;
            case State_Enum.Debut_State:
                CurrentState = new DebutState(this);
                return;
        }

    }
    public void StageManagerInit()
    {
        TransitionState(State_Enum.Waiting_State);
    }
    public void StageManagerUpdate()
    {
        CurrentState.OnUpdate();
    }
}
public struct StageData
{
    public RaceLength RepeatableRaceType { get; set; }

    public static StageData GetRepeatStageData(RaceLength  raceType)
    {
        return new StageData { RepeatableRaceType = raceType };
    }
}

