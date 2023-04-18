using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PinBallNamespace
{
    public class BallLauncher : MonoBehaviour
    {
       
        [SerializeField] private float nowPressedTime_;
        [Header("Max Force")]
        [SerializeField] private float  basicLaunchForce_;
        private const float MAX_PERCENTAGE = 1f;
        [Header("Charge need time")]
        [SerializeField] private float chargeUsedTime_;
       
        private float nowPercentage_ => MAX_PERCENTAGE/chargeUsedTime_*nowPressedTime_;
        private float nowForce_ => basicLaunchForce_ * nowPercentage_;

        private void Update()
        {
            chargedLaunch();
        }

        private void chargedLaunch()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                resetPressedTime();
            }
            if (Input.GetKey(KeyCode.Space))
            {
                addPressedTime();
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                ballAddForce();
            }
        }

        private void resetPressedTime()
        {
            nowPressedTime_ = 0;
        }

        private void addPressedTime()
        {
            nowPressedTime_ = AddTime(nowPressedTime_, chargeUsedTime_);            
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

