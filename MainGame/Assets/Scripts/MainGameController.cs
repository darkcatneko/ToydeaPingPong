using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameController : MonoBehaviour
{
    public static MainGameController Instance;
    public GameObject PlayerObject;
    public Rigidbody PlayerRigibody => PlayerObject.GetComponent<Rigidbody>();
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        
    }    
}
