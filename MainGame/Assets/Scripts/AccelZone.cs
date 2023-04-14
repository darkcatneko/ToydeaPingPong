using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelZone : MonoBehaviour
{
    [SerializeField] private float minSpeed_;
    [SerializeField] private float accelAmount_;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var playerRigid_ = MainGameController.Instance.PlayerRigidbody;
            var nowVelocity = playerRigid_.velocity.magnitude;            
            playerRigid_.velocity = getVelocityAfterBoost(nowVelocity);
            //get speed
            //boost speed
            //get velocity 
            //change player velocity
        }   
    }
    private Vector3 getVelocityAfterBoost(float velocity_)
    {
        velocity_ = Mathf.Clamp(velocity_*accelAmount_, minSpeed_, 2000);
        var result_ = Vector3.forward * velocity_;
        return result_;
    }
}
