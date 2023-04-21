using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceState : StateBase
{
    public RaceState(StageManager m) : base(m)
    {
    }

    public override void OnEnter()
    {
        MainGameController.Instance.RaceStart();
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {

    }
}
