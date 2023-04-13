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
            playerRigid_.velocity = boost(nowVelocity);
        }   
    }
    private Vector3 boost(float velocity)
    {
        velocity = Mathf.Clamp(velocity*accelAmount_, minSpeed_, 2000);
        var result = Vector3.forward * velocity;
        return result;
    }
}
