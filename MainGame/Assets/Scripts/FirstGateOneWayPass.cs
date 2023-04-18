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
        rightGate_.isTrigger = leftGate_.isTrigger = thisGateType_ == GateType.Outside;       
    }
}
[System.Serializable]
public enum GateType
{
    Outside,
    Inside,
    Exit,
}