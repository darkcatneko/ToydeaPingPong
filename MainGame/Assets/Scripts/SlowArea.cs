using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowArea : TriggerManager
{
    [SerializeField] private float slowPercentage_ = 0.25f;
    protected override string customTag2_ => "Enemy";
    protected override void onTriggerStayTag(Collider other)
    {
        var rigidbody = other.GetComponent<Rigidbody>();
        rigidbody.velocity = rigidbody.velocity * slowPercentage_;
    }    
}
