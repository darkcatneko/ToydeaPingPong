﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PinBallNamespace
{
    [System.Serializable]
    public class BallLauncher 
    {
        [Header("效果上限")]
        [SerializeField]private float  basicLaunchForce_ = 5000;
        [SerializeField] private float maxChargeNeedTime_ = 3f;
        private const float MAX_PERCENTAGE = 1f;
        [Header("按壓時間")]
        [SerializeField] private float nowPressedTime_;
       
       
        private float nowPercentage_ => MAX_PERCENTAGE/maxChargeNeedTime_*nowPressedTime_;
        private float nowForce_ => basicLaunchForce_ * nowPercentage_;
        
        public void LauncherWait()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                resetPressedTime();
                MainGameController.Instance.StageManager.TransitionState(State_Enum.Launch_State);
            }
        }
        public void LauncherLaunch()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                addPressedTime();
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                ballAddForce();
                MainGameController.Instance.StageManager.TransitionState(State_Enum.Debut_State);
            }
        }

        private void resetPressedTime()
        {
            nowPressedTime_ = 0;
        }

        private void addPressedTime()
        {
            nowPressedTime_ = AddTime(nowPressedTime_, maxChargeNeedTime_);            
        }

        public float AddTime(float nowTime_,float maxTime_)
        {
            var resultTime_ = nowTime_+Time.deltaTime;
            resultTime_ = Mathf.Clamp(resultTime_, 0, maxTime_);
            return resultTime_;
        }

        private void ballAddForce()
        {           
            var launchForce_ = Vector3.forward * nowForce_;
            MainGameController.Instance.PlayerAddForce(launchForce_);
        }


    }
}

