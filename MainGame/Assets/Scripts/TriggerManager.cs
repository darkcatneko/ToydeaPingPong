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
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(customTag_))
        {
            onTriggerStayTag(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(customTag_))
        {
           onTriggerExitTag(other); 
        }
    }

    protected virtual void onTriggerEnterTag(Collider other)
    {

    }
    protected virtual void onTriggerStayTag(Collider other)
    {

    }
    protected virtual void onTriggerExitTag(Collider other)
    {

    }
}
