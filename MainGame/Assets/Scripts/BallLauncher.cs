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
       
        private float nowPercentage_ => MAX_PERCENTAGE/nowPressedTime_;
        private float nowForce_ => basicLaunchForce_ * nowPercentage_;

        private void Update()
        {
            ChargedLaunch();
        }

        public void ChargedLaunch()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ResetPressedTime();
            }
            if (Input.GetKey(KeyCode.Space))
            {
                AddPressedTime();
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                BallAddForce();
            }
        }

        public void ResetPressedTime()
        {
            nowPressedTime_ = 0;
        }

        public void AddPressedTime()
        {
            nowPressedTime_ = AddTime(nowPressedTime_, chargeUsedTime_);            
        }

        public float AddTime(float nowTime_,float maxTime_)
        {
            var resultTime_ = nowTime_+Time.deltaTime;
            resultTime_ = Mathf.Clamp(resultTime_, 0, maxTime_);
            return resultTime_;
        }

        public void BallAddForce()
        {           
            var launchForce_ = Vector3.forward * nowForce_;
            MainGameController.Instance.PlayerAddForce(launchForce_);
        }



    }
}

