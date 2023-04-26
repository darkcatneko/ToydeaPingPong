using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Codice.Client.BaseCommands;

public class StoperMechanic 
{
    [SerializeField] public float PlayerStayTime;   
    private void doActionAfterStop(Action action,float stayTime,float actionTime,Vector3 objPos)
   {
        if (stayTime <= actionTime)
        {
            stop(objPos);
        }
        else
        {
            action.Invoke();
        }
    }
    public void StoperOnTriggerEnterBehavior()
    {
        PlayerStayTime = 0;
    }
    public void StoperOnTriggerStayBehavior(Action action, float stayTime, float actionTime, Vector3 objPos) 
    {
        PlayerStayTime += Time.deltaTime;
        doActionAfterStop(action, stayTime, actionTime,objPos);
    }
    private void stop(Vector3 objPos)
    {
        var stopPos = GetCenterOfPosition(objPos);
        MainGameController.Instance.PlayerChangePosition(stopPos);
        MainGameController.Instance.PlayerChangeVelocity(Vector3.zero);
    }
    public Vector3 GetCenterOfPosition(Vector3 position)
    {
        var objCenterPos_ = position;
        var player = MainGameController.Instance.PlayerObject;
        objCenterPos_.y = player.transform.position.y;
        return objCenterPos_;
    }
}
