using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTeleporter : TriggerManager
{
    [Header("TeleporterUsedMath")]
    [SerializeField]
    private float teleportNeedTime_;
    [SerializeField]
    private Transform teleportEndPos_;
    [Header("WhichRace")]
    [SerializeField]
    private RaceLength whichRace_;
    private Vector3 obj2DMapPos_ => new Vector3(transform.position.x, 0, transform.position.z);

    private Vector3 teleport2DMapPos_ => new Vector3(teleportEndPos_.transform.position.x, 0, teleportEndPos_.transform.position.z);

    private StoperMechanic stoper_ = new StoperMechanic();

    protected override void onTriggerEnterTag(Collider other)
    {
        stoper_.StoperOnTriggerEnterBehavior();
        //MainGameController.Instance.PlayerEnterTeleporter();
    }
    protected override void onTriggerStayTag(Collider other)
    {      
        stoper_.StoperOnTriggerStayBehavior(teleportPlayer, stoper_.PlayerStayTime, teleportNeedTime_,obj2DMapPos_);
    }
    
    private void teleportPlayer()
    {
        var teleportEndCenterPos = stoper_.GetCenterOfPosition(teleport2DMapPos_);
        MainGameController.Instance.PlayerChangePosition(teleportEndCenterPos);
        transitionToRaceState();
    }   
    private void transitionToRaceState()
    {
        var stageData = StageData.GetRepeatStageData(whichRace_);
        MainGameController.Instance.StageManager.TransitionState(State_Enum.Race_State, stageData);
    }
}
