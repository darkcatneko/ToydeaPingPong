using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    [SerializeField] private float magnification = 9.8f;
    private Vector3 gravity_ => new Vector3(0,-0.25f,-1) * magnification; 

    private Rigidbody playerRigid_ => MainGameController.Instance.PlayerRigidbody;

    private void FixedUpdate()
    {   
        playerRigid_.AddForce(gravity_);
    }
}
