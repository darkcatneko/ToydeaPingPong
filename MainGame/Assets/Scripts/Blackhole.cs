using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole : MonoBehaviour
{
    
    [SerializeField] 
    private float playerStayTime_;
    [SerializeField]
    private float launchNeedTime_;
    [SerializeField]
    private float launchSpeed_;
    private Vector3 obj2DMapPos_ => new Vector3(transform.position.x, 0, transform.position.z);
    private void OnTriggerEnter(Collider other)
    {
        playerStayTime_ = 0;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerStayTime_ += Time.deltaTime;          
            blackHoleLaunch();
        }
    }
    private void blackHoleLaunch()
    {
        if (playerStayTime_ <= launchNeedTime_)
        {
            stopInBlackHole();
            MainGameController.Instance.PlayerChangeVelocity(Vector3.zero);
        }
        else
        {
            var launchVelocity_ = new Vector3(-1, 0, -1) * launchSpeed_;
            MainGameController.Instance.PlayerChangeVelocity(launchVelocity_);
        }

    }
    private void stopInBlackHole()
    {
        var blackholeCenterPos_ = obj2DMapPos_;
        var player = MainGameController.Instance.PlayerObject;       
        blackholeCenterPos_.y = player.transform.position.y;
        MainGameController.Instance.PlayerChangePosition(blackholeCenterPos_);    
    }
    
}
