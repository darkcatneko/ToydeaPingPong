using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTeleporter : MonoBehaviour
{
    [SerializeField]
    private float playerStayTime_;
    [SerializeField]
    private float teleportNeedTime_;
    [SerializeField]
    private Transform teleportEndPos_;
    [SerializeField]
    private RaceLength whichRace_;

    private Vector3 obj2DMapPos_ => new Vector3(transform.position.x, 0, transform.position.z);

    private void stopInTeleporter()
    {
        var teleporterCenterPos_ = obj2DMapPos_;
        var player = MainGameController.Instance.PlayerObject;
        teleporterCenterPos_.y = player.transform.position.y;
        MainGameController.Instance.PlayerChangePosition(teleporterCenterPos_);
    }
}
