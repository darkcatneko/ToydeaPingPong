using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGateOneWayPass : TriggerManager
{
    [SerializeField] private GateType thisGateType_ = GateType.Outside;
    [Header("GateWay")]
    [SerializeField] private Collider rightGate_;
    [SerializeField] private Collider leftGate_;
    protected override void onTriggerEnterTag(Collider other)
    {
        if (thisGateType_ == GateType.Outside)
        {
            rightGate_.isTrigger = true;
            leftGate_.isTrigger = true;
        }
        else
        {
            rightGate_.isTrigger = false;
            leftGate_.isTrigger = false;
        }
        
       
    }
}
[System.Serializable]
public enum GateType
{
    Outside,
    Inside,
}