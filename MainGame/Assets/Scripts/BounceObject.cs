using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BounceObject : MonoBehaviour
{
    [SerializeField] private float unitElasticity_ = 1.2f;
    [SerializeField] private float minSpeed_ = 20f;

    void OnCollisionEnter(Collision collision)
    {
        var otherObject_ = collision.gameObject;
        if (otherObject_.CompareTag("Player"))
        {
            var velocityAfterCollision_ = GetVelocityAfterCollision_(collision);
            MainGameController.Instance.PlayerChangeVelocity(velocityAfterCollision_);
        }
    }

    public Vector3 GetVelocityAfterCollision_(Collision collision)
    {
        var dirAfterReflection_ = GetDirAfterReflection(collision);
        var speedAfterCollisionEvent_ = GetSpeedAfterCollisionEvent(collision);
        var velocityAfterCollision_ = dirAfterReflection_ * speedAfterCollisionEvent_;
        return velocityAfterCollision_;
    }

    public float GetSpeedAfterCollisionEvent(Collision collision)
    {
        //得到速率
        var speedOfCollision = GetSpeedOfCollision(collision);
        //彈性加成
        var velocityAfterElasticity_ = GetSpeedAfterElasticity(speedOfCollision);
        //限制速率
        var limitedSpeed_ = GetLimitedSpeed(velocityAfterElasticity_, minSpeed_);

        return limitedSpeed_;
    }

    public Vector3 GetDirAfterReflection(Collision collision_)
    {
        var normal_ = collision_.contacts[0].normal;

        var velocity_ = collision_.relativeVelocity;

        var bounceDirection_ = Vector3.Reflect(velocity_.normalized, normal_);

        return bounceDirection_;
    }

    public float GetSpeedOfCollision(Collision collision_)
    {
        var velocity_ = collision_.relativeVelocity;
        return velocity_.magnitude;
    }

    public float GetSpeedAfterElasticity(float previousSpeed_)

    {
        var speedAfterElasticity_ = previousSpeed_ * unitElasticity_;
        return speedAfterElasticity_;
    }

    public float GetLimitedSpeed(float previousSpeed_, float minSpeed_)
    {
        var maxSpeed_ = 1000f;
        return Mathf.Clamp(previousSpeed_, minSpeed_, maxSpeed_);
    }



}
