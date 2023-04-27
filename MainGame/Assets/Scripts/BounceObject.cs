using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BounceObject : CollisionManager
{
    protected override string customTag2_ => "Enemy";
    [Header("彈力")]
    [SerializeField] private float unitElasticity_ = 1.2f;
    [Header("最低限速")]
    [SerializeField] private float minSpeed_ = 20f;
    [Header("最高限速")]
    [SerializeField] private float maxSpeed_ = 100f;

    protected override void onCollisionTag(Collision collision)
    {
        var velocityAfterCollision = getVelocityAfterCollision_(collision);
        MainGameController.Instance.PlayerChangeVelocity(velocityAfterCollision);
    }
    protected override void onCollisionTag2(Collision collision)
    {
        var velocityAfterCollision = getVelocityAfterCollision_(collision);
        collision.rigidbody.velocity = velocityAfterCollision;
    }

    private Vector3 getVelocityAfterCollision_(Collision collision)
    {
        var dirAfterReflection = getDirAfterReflection(collision);
        var speedAfterCollisionEvent = getSpeedAfterCollisionEvent(collision);
        var velocityAfterCollision = dirAfterReflection * speedAfterCollisionEvent;
        return velocityAfterCollision;
    }

    private float getSpeedAfterCollisionEvent(Collision collision)
    {
        //得到速率
        var speedOfCollision = getSpeedOfCollision(collision);
        //彈性加成
        var velocityAfterElasticity = getSpeedAfterElasticity(speedOfCollision);
        //限制速率
        var limitedSpeed = getLimitedSpeed(velocityAfterElasticity, minSpeed_);

        return limitedSpeed;
    }

    private Vector3 getDirAfterReflection(Collision collision)
    {
        var normal = collision.contacts[0].normal;

        var velocity = collision.relativeVelocity;

        var bounceDirection = Vector3.Reflect(velocity.normalized, normal);

        return bounceDirection;
    }

    private float getSpeedOfCollision(Collision collision)
    {
        var velocity = collision.relativeVelocity;
        return velocity.magnitude;
    }

    private float getSpeedAfterElasticity(float previousSpeed)

    {
        var speedAfterElasticity = previousSpeed * unitElasticity_;
        return speedAfterElasticity;
    }

    private float getLimitedSpeed(float previousSpeed, float minSpeed)
    {
        return Mathf.Clamp(previousSpeed, minSpeed, maxSpeed_);
    }



}
