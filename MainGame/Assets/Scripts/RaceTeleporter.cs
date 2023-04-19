using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTeleporter : TriggerManager
{
    [Header("TeleporterUsedMath")]
    [SerializeField]
    private float playerStayTime_;
    [SerializeField]
    private float teleportNeedTime_;
    [SerializeField]
    private Transform teleportEndPos_;
    [Header("WhichRace")]
    [SerializeField]
    private RaceLength whichRace_;
    private Vector3 obj2DMapPos_ => new Vector3(transform.position.x, 0, transform.position.z);

    private Vector3 teleport2DMapPos_ => new Vector3(teleportEndPos_.transform.position.x, 0, teleportEndPos_.transform.position.z);

    protected override void onTriggerEnterTag(Collider other)
    {
        playerStayTime_ = 0;
    }
    protected override void onTriggerStayTag(Collider other)
    {
        playerStayTime_ += Time.deltaTime;
        teleport();
    }
    private void teleport()
    {
        if (playerStayTime_ <= teleportNeedTime_)
        {
            stopInTeleporter();
            MainGameController.Instance.PlayerChangeVelocity(Vector3.zero);
        }
        else
        {
            var teleportEndCenterPos = GetCenterOfPosition(teleport2DMapPos_);            
            MainGameController.Instance.PlayerChangePosition(teleportEndPos_.position);
        }

    }

    private void stopInTeleporter()
    {
        var teleporterCenterPos_ = GetCenterOfPosition(obj2DMapPos_);
        MainGameController.Instance.PlayerChangePosition(teleporterCenterPos_);
    }
    private Vector3 GetCenterOfPosition(Vector3 position)
    {
        var objCenterPos_ = position;
        var player = MainGameController.Instance.PlayerObject;
        objCenterPos_.y = player.transform.position.y;
        return objCenterPos_;
    }
}
