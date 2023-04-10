using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private float launchForce_ = 1f;
    public void BallAddForce()
    {
        var player = MainGameController.Instance.PlayerObject;
        var playerRigi = player.GetComponent<Rigidbody>();
        Vector3 test = new Vector3(0, 0, 1) * launchForce_; 
        playerRigi.AddForce(test);
    }
}
