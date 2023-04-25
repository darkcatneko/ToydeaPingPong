using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceTrigger : TriggerManager
{
    private enum fenceBehavior
    {
        Open,
        Close,
    }
    private enum fenceDirection
    {
        Right,
        Left,
    }

    [Header("Fence")]
    [SerializeField]
    private HingeJoint rightFenceHinge_;
    [SerializeField]
    private HingeJoint leftFenceHinge_;
    [Header("HingeJoint")]
    [SerializeField] private float restPosition_ = 0f;
    [SerializeField] private float pressedPosition_ = 90f;
    [SerializeField] private float hitStrength_ = 10000f;
    [SerializeField] private float flipperDamper_ = 150f;
    protected override void onTriggerEnterTag(Collider other)
    {
        FenceMechanic(fenceBehavior.Open);
    }    
    protected override void onTriggerExitTag(Collider other) 
    {
        FenceMechanic(fenceBehavior.Close);
    }
    private void FenceMechanic(fenceBehavior fenceBehavior)
    {
        rightFenceHinge_.spring = SetFence(fenceBehavior, fenceDirection.Right);

        leftFenceHinge_.spring = SetFence(fenceBehavior, fenceDirection.Left);
    }
    private JointSpring SetFence(fenceBehavior fenceBehavior,fenceDirection whichfence)
    {
        var spring = new JointSpring();
        spring.spring = hitStrength_;
        spring.damper = flipperDamper_;
        var targetPosition = fenceBehavior == fenceBehavior.Open ? pressedPosition_ : restPosition_;
        var targetPositionByDirection = whichfence == fenceDirection.Right ? -1*targetPosition : 1*targetPosition;
        spring.targetPosition = targetPositionByDirection;
        return spring;
    }
}

