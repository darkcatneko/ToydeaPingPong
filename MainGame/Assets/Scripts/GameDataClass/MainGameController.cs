using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using PinBallNamespace;
using System;
using UnityEngine.SceneManagement;

public class MainGameController : ToSingletonMonoBehavior<MainGameController>
{
    public GameObject PlayerObject;
    public Rigidbody PlayerRigidbody;
    public BallLauncher BallLauncher;
    public MainGameEvents MainGameEvents_ = new MainGameEvents(); //小概念
    private StageManager StageManager = new StageManager();//小概念
    protected override void init()
    {
        StageManager.StageManagerInit();
    }
    private void Start()
    {
        MainGameEvents_.GameStartEvent.Invoke();
    }
    private void Update()
    {
        StageManager.StageManagerUpdate();
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    #region playerPhysic
    public void SetPlayerRigidbody()
    {
        PlayerRigidbody = PlayerObject.GetComponent<Rigidbody>();
    }

    public void PlayerAddForce(Vector3 force)
    {
        PlayerRigidbody.AddForce(force);
    }

    public void PlayerChangeVelocity(Vector3 velocity)
    {
        PlayerRigidbody.velocity = velocity;
    }
    #endregion

    public void PlayerChangePosition(Vector3 finalPos)
    {
        PlayerObject.transform.position = finalPos;
    }
    
    public void GameRestart()
    {
        MainGameEvents_.GameRestartEvent.Invoke();
        StageManager.TransitionState(State_Enum.Waiting_State);
    }
    public void RaceStart()
    {
        MainGameEvents_.RaceStartEvent.Invoke();
    }
    public void RaceSkillActivate()
    {
        MainGameEvents_.RaceSkillActivateEvent.Invoke();
    }
    public void TransitionState(State_Enum type)
    {
        StageManager.TransitionState(type);
    } 
}
