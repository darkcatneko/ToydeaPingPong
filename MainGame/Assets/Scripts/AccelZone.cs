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
            var nowPlayerSpeed_ = playerRigid_.velocity.magnitude;
            var velocityAfterBoost_ = getVelocityAfterBoost(nowPlayerSpeed_,Vector3.forward);
            MainGameController.Instance.PlayerChangeVelocity(velocityAfterBoost_);
        }   
    }
    private Vector3 getVelocityAfterBoost(float speed_,Vector3 direction)
    {
        speed_ = Mathf.Clamp(speed_*accelAmount_, minSpeed_, 2000);
        var velocityAfterBoost_ = direction * speed_;
        return velocityAfterBoost_;
    }
}
