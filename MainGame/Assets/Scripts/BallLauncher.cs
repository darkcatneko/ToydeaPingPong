using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private float launchForce_ = 1f;
    public void BallAddForce()
    {
        var playerRigi = MainGameController.Instance.PlayerRigibody;
        var force_ = Vector3.forward * launchForce_;
        playerRigi.AddForce(force_);
    }
}
