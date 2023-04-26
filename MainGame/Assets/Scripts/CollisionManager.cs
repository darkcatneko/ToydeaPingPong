using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    protected virtual string customTag_ {  get; } = "Player";
    protected virtual string customTag2_ { get; } = "Player";
    private void onCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(customTag_))
        {
            onCollisionTag(collision);
        }
        if (collision.gameObject.CompareTag(customTag2_))
        {
            onCollisionTag2(collision);
        }
    }

    protected virtual void onCollisionTag(Collision collision)
    {

    }
    protected virtual void onCollisionTag2(Collision collision)
    {
        
    }
}