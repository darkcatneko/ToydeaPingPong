using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    protected virtual string customTag_ { get; } = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(customTag_))
        {
            onTriggerEnterTag(other);
        }
    }

    protected virtual void onTriggerEnterTag(Collider other)
    {

    }
}
