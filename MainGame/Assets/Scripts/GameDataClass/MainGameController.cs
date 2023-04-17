using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MainGameController : TSingletonMonoBehavior<MainGameController>
{
    public GameObject PlayerObject;
    public GameData ThisGameData;
    public Rigidbody PlayerRigidbody => PlayerObject.GetComponent<Rigidbody>();
    public UnityEvent GameRestartEvent = new UnityEvent();
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

    public void PlayerChangePosition(Vector3 finalPos)
    {
        PlayerObject.transform.position = finalPos;
    }

    public void GameRestart()
    {
        GameRestartEvent.Invoke();
    }
}
