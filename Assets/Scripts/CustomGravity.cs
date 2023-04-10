using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    private Vector3 gravity_ = new Vector3(0, 0, -1) * 9.8f;
    private void FixedUpdate()
    {
        var playerRigi = MainGameController.Instance.PlayerRigibody;
        playerRigi.AddForce(gravity_);
    }
}
