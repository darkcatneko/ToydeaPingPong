using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameController : TSingletonMonoBehavior<MainGameController>
{
    public GameObject PlayerObject;
    public Rigidbody PlayerRigidbody => PlayerObject.GetComponent<Rigidbody>();
    private void Start()
    {
        
    }    
    public void PlayerAddForce(Vector3 force)
    {
        PlayerRigidbody.AddForce(force);
    }
    public void PlayerChangeVelocity(Vector3 velocity)
    {
        PlayerRigidbody.velocity = velocity;
    }
}
