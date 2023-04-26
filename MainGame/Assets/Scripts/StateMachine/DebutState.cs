using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebutState : StateBase
{
    public DebutState(StageManager m) : base(m)
    {
    }

    public override void OnEnter()
    {
        MainGameController.Instance.DebutRaceStart();
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {

    }
}
