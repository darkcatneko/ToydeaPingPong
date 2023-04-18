using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccelZoneNamespace
{
    public class AccelerationZone : TriggerManager
    {
        [SerializeField] private float minSpeed_ = 20;
        [SerializeField] private float maxSpeed_ = 2000f;
        [SerializeField] private float accelAmount_ = 1.5f;
        [SerializeField] private Vector3 accelerationDir = Vector3.forward;
        protected override void onTriggerEnterTag(Collider other)
        {
            var playerRigid = MainGameController.Instance.PlayerRigidbody;
            var nowPlayerSpeed = playerRigid.velocity.magnitude;
            var speedAfterBoost = GetSpeedAfterBoost(nowPlayerSpeed);
            var velocityAfterBoost = getVelocityAfterBoost(speedAfterBoost, accelerationDir);
            MainGameController.Instance.PlayerChangeVelocity(velocityAfterBoost);
        }

        public float GetSpeedAfterBoost(float nowPlayerSpeed)
        {
            var speedAfterBoost = Mathf.Clamp(nowPlayerSpeed * accelAmount_, minSpeed_, maxSpeed_);
            return speedAfterBoost;
        }
        
        private Vector3 getVelocityAfterBoost(float speed, Vector3 direction)
        {
            var velocityAfterBoost = speed * direction;
            return velocityAfterBoost;
        }
        
    }
}

