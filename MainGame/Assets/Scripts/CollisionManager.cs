using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    protected virtual string customTag_ { get; } = "Player";
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(customTag_))
        {
            OnCollisionTag(collision);
        }
    }
    protected virtual void OnCollisionTag(Collision collision)
    {

    }
}