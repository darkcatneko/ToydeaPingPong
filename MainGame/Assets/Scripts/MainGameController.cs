using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameController : MonoBehaviour
{
    public static MainGameController Instance;
    public GameObject PlayerObject;
    public Rigidbody PlayerRigidbody => PlayerObject.GetComponent<Rigidbody>();
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        
    }    
    public void PlayerAddForce(Vector3 force_)
    {
        PlayerRigidbody.AddForce(force_);
    }
    public void PlayerChangeVelocity(Vector3 velocity_)
    {
        PlayerRigidbody.velocity = velocity_;
    }
}
