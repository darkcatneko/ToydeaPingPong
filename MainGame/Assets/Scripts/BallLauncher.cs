using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private float launchForce_;
    private Rigidbody playerRigid_ => MainGameController.Instance.PlayerRigidbody;
    private void Update()
    {
        
    }
    public void BallAddForce()
    {
        var force_ = Vector3.forward * launchForce_;
        playerRigid_.AddForce(force_);
    }
    public void ChargedLaunch()
    {

    }
}
