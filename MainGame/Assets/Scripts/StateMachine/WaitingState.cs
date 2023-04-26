using PinBallNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitingState : StateBase
{
    private BallLauncher ballLauncher_ => MainGameController.Instance.BallLauncher;
    public WaitingState(StageManager m) : base(m)
    {
    }

    public override void OnEnter()
    {

    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        ballLauncher_.LauncherWait();
    }
}
