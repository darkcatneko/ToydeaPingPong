using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase 
{
    protected StageManager stateManager;
    public StateBase(StageManager m)
    {
        stateManager = m;
    }

    public virtual void OnEnter()
    {

    }

    public virtual void OnUpdate()
    {

    }

    public virtual void OnExit()
    {

    }
}
public enum State_Enum
{
    Waiting_State, Launch_State, Race_State,Training_State,Debut_State,Video_State,
}
