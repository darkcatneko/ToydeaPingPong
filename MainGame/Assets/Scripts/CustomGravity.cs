using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    private Vector3 gravity_ = new Vector3(0,-0.25f,-1) * 9.8f; 
    private Rigidbody playerRigid_ => MainGameController.Instance.PlayerRigidbody;
    private void Start()
    {
    }
    private void FixedUpdate()
    {   
        playerRigid_.AddForce(gravity_);
    }
}
