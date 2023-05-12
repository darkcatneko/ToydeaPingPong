using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FirstGateFence : TriggerManager
{
    [SerializeField] private GameObject fenceObj_;
    [SerializeField] private float fenceHighestPos_;
    [SerializeField] private float clostOROpenTime_;
    protected override void onTriggerEnterTag(Collider other)
    {
        var finalPos = fenceHighestPos_;
        fenceObj_.transform.DOMoveY(finalPos, clostOROpenTime_);
    }    
    public void CloseThisGate()
    {
        var finalPos = 0;
        fenceObj_.transform.DOMoveY(finalPos, clostOROpenTime_);
    }
    public void OpenThisGate()
    {
        var finalPos = fenceHighestPos_;
        fenceObj_.transform.DOMoveY(finalPos, clostOROpenTime_);
    }
}
