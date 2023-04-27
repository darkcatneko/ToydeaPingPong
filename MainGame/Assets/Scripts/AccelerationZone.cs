using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccelZoneNamespace
{
    public class AccelerationZone : TriggerManager
    {
        [Header("效果上限")]
        [SerializeField] private float minSpeed_ = 20;
        [SerializeField] private float maxSpeed_ = 2000f;
        [Header("效果數值")]
        [SerializeField] private float accelAmount_ = 1.5f;
        private Vector3 accelerationDir_ => transform.forward;
        protected override void onTriggerEnterTag(Collider other)
        {
            var playerVelocityAfterBoost = getPlayerVelocityAfterBoost();
            MainGameController.Instance.PlayerChangeVelocity(playerVelocityAfterBoost);
        }
        private Vector3 getPlayerVelocityAfterBoost()
        {
            var playerRigid = MainGameController.Instance.PlayerRigidbody;
            var nowPlayerSpeed = playerRigid.velocity.magnitude;
            var speedAfterBoost = GetSpeedAfterBoost(nowPlayerSpeed);
            var velocityAfterBoost = getVelocityAfterBoost(speedAfterBoost, accelerationDir_);
            return velocityAfterBoost;
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

