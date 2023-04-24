using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowArea : TriggerManager
{
    [SerializeField] private float slowPercentage_ = 0.25f;
    protected override void onTriggerStayTag(Collider other)
    {
        MainGameController.Instance.PlayerRigidbody.velocity = MainGameController.Instance.PlayerRigidbody.velocity * slowPercentage_;
    }
}
