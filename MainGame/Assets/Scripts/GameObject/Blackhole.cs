﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole : TriggerManager
{
    [Header("發射需要時間")]
    [SerializeField]
    private float launchNeedTime_;
    [Header("發射速度")]
    [SerializeField]
    private float launchSpeed_;
    [Header("發射方向")]
    [SerializeField]
    private Vector3 launchDir_ = new Vector3(-1, 0, -1);
    private Vector3 obj2DMapPos_ => new Vector3(transform.position.x, 0, transform.position.z);

    private StoperMechanic stoper_ = new StoperMechanic();

    protected override void onTriggerEnterTag(Collider other)
    {
        stoper_.StoperOnTriggerEnterBehavior();
    }

    protected override void onTriggerStayTag(Collider other)
    {        
        stoper_.StoperOnTriggerStayBehavior(launchPlayer, stoper_.PlayerStayTime, launchNeedTime_, obj2DMapPos_);
    }
    private void launchPlayer()
    {
        var launchVelocity_ = launchDir_ * launchSpeed_;
        MainGameController.Instance.PlayerChangeVelocity(launchVelocity_);
    }
    
}
