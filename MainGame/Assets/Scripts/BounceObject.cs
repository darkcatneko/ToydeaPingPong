using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BounceObject : CollisionManager
{
    [SerializeField] private float unitElasticity_ = 1.2f;
    [SerializeField] private float minSpeed_ = 20f;

    protected override void onCollisionTag(Collision collision)
    {
        var velocityAfterCollision = GetVelocityAfterCollision_(collision);
        MainGameController.Instance.PlayerChangeVelocity(velocityAfterCollision);
    }

    public Vector3 GetVelocityAfterCollision_(Collision collision)
    {
        var dirAfterReflection = GetDirAfterReflection(collision);
        var speedAfterCollisionEvent = GetSpeedAfterCollisionEvent(collision);
        var velocityAfterCollision = dirAfterReflection * speedAfterCollisionEvent;
        return velocityAfterCollision;
    }

    public float GetSpeedAfterCollisionEvent(Collision collision)
    {
        //得到速率
        var speedOfCollision = GetSpeedOfCollision(collision);
        //彈性加成
        var velocityAfterElasticity = GetSpeedAfterElasticity(speedOfCollision);
        //限制速率
        var limitedSpeed = GetLimitedSpeed(velocityAfterElasticity, minSpeed_);

        return limitedSpeed;
    }

    public Vector3 GetDirAfterReflection(Collision collision)
    {
        var normal = collision.contacts[0].normal;

        var velocity = collision.relativeVelocity;

        var bounceDirection = Vector3.Reflect(velocity.normalized, normal);

        return bounceDirection;
    }

    public float GetSpeedOfCollision(Collision collision)
    {
        var velocity = collision.relativeVelocity;
        return velocity.magnitude;
    }

    public float GetSpeedAfterElasticity(float previousSpeed)

    {
        var speedAfterElasticity = previousSpeed * unitElasticity_;
        return speedAfterElasticity;
    }

    public float GetLimitedSpeed(float previousSpeed, float minSpeed)
    {
        var maxSpeed = 1000f;
        return Mathf.Clamp(previousSpeed, minSpeed, maxSpeed);
    }



}
