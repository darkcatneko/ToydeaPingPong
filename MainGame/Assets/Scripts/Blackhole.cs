using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole : MonoBehaviour
{
    private Vector3 onMapPos => new Vector3(this.transform.position.x, 0, this.transform.position.z);
    [SerializeField] 
    private float playerStayTime_;
    [SerializeField]
    private float launchTime_;
    [SerializeField]
    private float launchSpeed_;
    private Rigidbody playerRigid => MainGameController.Instance.PlayerRigidbody;
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
    private void stopInBlackHole()
    {
        var player = MainGameController.Instance.PlayerObject;
        var blackPos_ = onMapPos;
        blackPos_.y = player.transform.position.y;
        player.gameObject.transform.position = blackPos_;       
    }
    private void blackHoleLaunch()
    {
        if (playerStayTime_ <= launchTime_)
        {
            stopInBlackHole();
            playerRigid.velocity = Vector3.zero;
        }
        else
        {
            var launchVelocity_ = new Vector3(-1,0,-1) * launchSpeed_;
            playerRigid.velocity = launchVelocity_;
        }
        
    }
}
