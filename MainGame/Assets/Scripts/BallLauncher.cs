using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private float launchForce_;
    [SerializeField] private float nowPercentage_;
    private const float MAX_PERCENTAGE = 100f;
    [SerializeField] private float chargeUsedTime_;
    
    private Rigidbody playerRigid_ => MainGameController.Instance.PlayerRigidbody;
    private void Update()
    {
        ChargedLaunch();
    }
    public void BallAddForce()
    {
        var force_ = Vector3.forward * launchForce_*nowPercentage_*0.01f;
        playerRigid_.AddForce(force_);
    }
    public void ChargedLaunch()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nowPercentage_ = 0;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            nowPercentage_ += (MAX_PERCENTAGE / chargeUsedTime_) * Time.deltaTime;
            nowPercentage_ = Mathf.Clamp(nowPercentage_, 0, MAX_PERCENTAGE);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            BallAddForce();
        }
    }
    
}
