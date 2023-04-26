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

    private StoperMechanic stoper = new StoperMechanic();

    protected override void onTriggerEnterTag(Collider other)
    {
        stoper.StoperOnTriggerEnterBehavior();
    }
    protected override void onTriggerStayTag(Collider other)
    {      
        stoper.StoperOnTriggerStayBehavior(teleportPlayer, stoper.playerStayTime_, teleportNeedTime_,obj2DMapPos_);
    }
    
    private void teleportPlayer()
    {
        var teleportEndCenterPos = stoper.GetCenterOfPosition(teleport2DMapPos_);
        MainGameController.Instance.PlayerChangePosition(teleportEndCenterPos);
        var stageData = StageData.GetRepeatStageData(whichRace_);
        MainGameController.Instance.StageManager.TransitionState(State_Enum.Race_State, stageData);
    }   
}
