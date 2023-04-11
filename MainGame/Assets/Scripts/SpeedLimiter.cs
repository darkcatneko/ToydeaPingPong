using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLimiter
{
    private Rigidbody playerRigid_ => MainGameController.Instance.PlayerRigidbody;
    private GameObject playerObj => MainGameController.Instance.PlayerObject;

    public void SpeedLimit()
    {
        var nowVelocity_ = playerRigid_.velocity;
        var nowSpeed_ = nowVelocity_.magnitude;
        var nowDirection_ = nowVelocity_.normalized;
        var currentPos_ = playerObj.transform.position;
        var nextTickPos_ = currentPos_ + nowVelocity_ * Time.fixedDeltaTime;

        RaycastHit hit;
        if (Physics.Raycast(playerObj.transform.position, playerObj.transform.forward , out hit, 10))
        {
            // �p�G�����F����A�h���L�������骺�W�r�M�����I����m
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
            Debug.Log("Hit point: " + hit.point);
        }
        //var targetWall_
    }

}
