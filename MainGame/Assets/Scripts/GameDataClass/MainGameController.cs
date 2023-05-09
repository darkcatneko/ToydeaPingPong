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
    public StageManager StageManager = new StageManager();//小概念
    protected override void init()
    {
        
    }
    private void Start()
    {
        StageManager.StageManagerInit();
       
    }

    private void Update()
    {
        StageManager.StageManagerUpdate();
        reloadGameCheatCode();
    }
    private void reloadGameCheatCode()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            StageManager.TransitionState(State_Enum.Waiting_State);
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
    #region CallGameEvent
    public void GameStart()
    {
        MainGameEvents_.GameStartEvent.Invoke();
        StageManager.TransitionState(State_Enum.Waiting_State);
    }
    public void GameRestart()
    {
        MainGameEvents_.GameRestartEvent.Invoke();
        StageManager.TransitionState(State_Enum.Waiting_State);
    }
    public void GameOver()
    {
        MainGameEvents_.GameOverEvent.Invoke();
    }
    
    public void PlayerPassGoal()
    {
        MainGameEvents_.PlayerPassGoalEvent.Invoke();
    }
    public void EnemyPassGoal()
    {
        MainGameEvents_.EnemyPassGoalEvent.Invoke();
    }
    public void TrainingEvent(Attributes attributes,int addAmount)
    {
        MainGameEvents_.TrainingEvent.Invoke(attributes, addAmount);
    }
    public void DebutRaceStart()
    {
        MainGameEvents_.DebutRaceStartEvent.Invoke();
        MainGameEvents_.RaceStartEvent.Invoke();
    }
    public void RepeatableRaceStart(RaceLength startedRace)
    {
        MainGameEvents_.RepeatableRaceStartEvent.Invoke(startedRace);
        MainGameEvents_.RaceStartEvent.Invoke();
    }
    public void PlayerEnterTeleporter()
    {
        MainGameEvents_.PlayerEnterTeleporterEvent.Invoke();
    }
    public void PlayerFirstEnterField()
    {
        MainGameEvents_.PlayerFirstEnterFieldEvent.Invoke();
    }
    public void PlayerShouldRankUp()
    {
        MainGameEvents_.PlayerShouldRankUpEvent.Invoke();
    }
    public void PlayerRankedUp()
    {
        MainGameEvents_.PlayerRankedUpEvent.Invoke();
    }
    public void PlayerEatCarrot()
    {
        MainGameEvents_.PlayerEatCarrotEvent.Invoke();
    }
    #endregion
    

    private void stopStartVideoAnimation()
    {
       
    }
}
