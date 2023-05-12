using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    protected virtual string customTag_ { get; } = "Player";
    protected virtual string customTag2_ { get; } = "Enemy";
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(customTag_))
        {
            onTriggerEnterTag(other);
        }
        if ( other.gameObject.CompareTag(customTag2_))
        {
            onTriggerEnterOther(other);
        }
        if (other.gameObject.CompareTag(customTag_) || other.gameObject.CompareTag(customTag2_))
        {
            onTriggerEnterBoth(other);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(customTag_) || other.gameObject.CompareTag(customTag2_))
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
    protected virtual void onTriggerEnterOther(Collider other)
    {

    }
    protected virtual void onTriggerEnterBoth(Collider other)
    {

    }
}
