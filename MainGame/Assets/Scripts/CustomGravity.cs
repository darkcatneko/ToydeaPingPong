using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    private Vector3 gravity_ = Vector3.back * 9.8f;
    private Rigidbody playerRigi_ => MainGameController.Instance.PlayerRigibody;     
    private void FixedUpdate()
    {   
        playerRigi_.AddForce(gravity_);
    }
}
