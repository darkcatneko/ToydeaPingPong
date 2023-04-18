using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FirstGateFence : TriggerManager
{
    [SerializeField] private GameObject fenceObj_;
    [SerializeField] private GateType thisGateType_;
    [SerializeField] private float fenceHighestPos_;
    [SerializeField] private float clostOROpenTime_;
    protected override void onTriggerEnterTag(Collider other)
    {
        if (thisGateType_ == GateType.Inside)
        {
            fenceObj_.transform.DOMoveY(fenceHighestPos_, clostOROpenTime_);
        }
        else
        {
            fenceObj_.transform.DOMoveY(0, clostOROpenTime_);
        }
    }
}
