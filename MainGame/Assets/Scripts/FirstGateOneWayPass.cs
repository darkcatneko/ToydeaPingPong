using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FirstGateOneWayPass : TriggerManager
{
    protected override string customTag2_ => "Enemy";
    [SerializeField] private GateType thisGateType_ = GateType.Outside;
    [Header("GateWay")]
    [SerializeField] private Collider rightGate_;
    [SerializeField] private Collider leftGate_;
    [SerializeField] private int inBall_;
    private void Start()
    {
        MainGameController.Instance.MainGameEvents_.RaceStartEvent.AddListener(resetInBall);
    }

    protected override void onTriggerEnterBoth(Collider other)
    {
        
        if (thisGateType_ == GateType.Inside)
        {
            inBall_ += 1;
            if (inBall_==9)
            {
                rightGate_.isTrigger = leftGate_.isTrigger = false;
                inBall_ = 0;
            }
        }
        else
        {
            rightGate_.isTrigger = leftGate_.isTrigger = true;
        }    
    }

    private void resetInBall()
    {
        inBall_ = 0;
    }
}
[System.Serializable]
public enum GateType
{
    Outside,
    Inside,
    Exit,
}