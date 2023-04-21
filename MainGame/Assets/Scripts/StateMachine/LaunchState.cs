using PinBallNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchState : StateBase
{
    private BallLauncher ballLauncher_ => MainGameController.Instance.BallLauncher;
    public LaunchState(StageManager m) : base(m)
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
        ballLauncher_.LauncherLaunch();
    }
}
