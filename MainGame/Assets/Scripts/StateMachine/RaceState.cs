using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceState : StateBase
{
    public RaceLength StartedRace;
    public RaceState(StageManager m,RaceLength startedRace) : base(m)
    {
        StartedRace = startedRace;
    }

    public override void OnEnter()
    {
        MainGameController.Instance.RepeatableRaceStart(StartedRace);
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {

    }
}
