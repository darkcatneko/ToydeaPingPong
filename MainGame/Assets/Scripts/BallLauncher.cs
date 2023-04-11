using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private float launchForce_;
    private Rigidbody playerRigi_ => MainGameController.Instance.PlayerRigibody;
    private void Update()
    {
        
    }
    public void BallAddForce()
    {
        var force_ = Vector3.forward * launchForce_;
        playerRigi_.AddForce(force_);
    }
    public void ChargedLaunch()
    {

    }
}
