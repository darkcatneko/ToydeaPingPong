using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    private Vector3 gravity_ = Vector3.back * 9.8f;
    private Rigidbody playerRigid_ => MainGameController.Instance.PlayerRigidbody;
    private SpeedLimiter speedLimiter_ ;
    private void Start()
    {
        speedLimiter_ = new SpeedLimiter(); 
    }
    private void FixedUpdate()
    {   
        playerRigid_.AddForce(gravity_);
        speedLimiter_.SpeedLimit();
    }
}
