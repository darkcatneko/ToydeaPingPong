using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StoperMechanic : MonoBehaviour
{
   public void DoStop(Action action,float stayTime,float actionTime,Vector3 objPos)
   {
        if (stayTime <= actionTime)
        {
            var stopPos = GetCenterOfPosition(objPos);
            MainGameController.Instance.PlayerChangePosition(stopPos);
            MainGameController.Instance.PlayerChangeVelocity(Vector3.zero);
        }
        else
        {
            action.Invoke();
        }
    }
    public Vector3 GetCenterOfPosition(Vector3 position)
    {
        var objCenterPos_ = position;
        var player = MainGameController.Instance.PlayerObject;
        objCenterPos_.y = player.transform.position.y;
        return objCenterPos_;
    }
}
