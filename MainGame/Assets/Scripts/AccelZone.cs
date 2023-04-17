using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccelZoneNamespace
{
    public class AccelZone : TriggerManager
    {
        [SerializeField] private float minSpeed_ = 20;
        [SerializeField] private float accelAmount_ = 1.5f;
        protected override void onTriggerEnterTag(Collider other)
        {
            var playerRigid = MainGameController.Instance.PlayerRigidbody;
            var nowPlayerSpeed = playerRigid.velocity.magnitude;
            var speedAfterBoost = GetSpeedAfterBoost(nowPlayerSpeed);
            var velocityAfterBoost = GetVelocityAfterBoost(speedAfterBoost, Vector3.forward);
            MainGameController.Instance.PlayerChangeVelocity(velocityAfterBoost);
        }

        public float GetSpeedAfterBoost(float nowPlayerSpeed)
        {
            var maxSpeed = 2000f;
            var speedAfterBoost = Mathf.Clamp(nowPlayerSpeed * accelAmount_, minSpeed_, maxSpeed);
            return speedAfterBoost;
        }

        public Vector3 GetVelocityAfterBoost(float speed, Vector3 direction)
        {
            var velocityAfterBoost = speed * direction;
            return velocityAfterBoost;
        }
    }
}

