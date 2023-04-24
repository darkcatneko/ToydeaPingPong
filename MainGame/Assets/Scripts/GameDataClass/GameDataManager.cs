using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public GameData ThisGameData = new GameData();
    private MainGameEvents gameEvents_ => MainGameController.Instance.MainGameEvents_;
    private RaceInfos raceInfos_ = new RaceInfos();
    private float[] PricePrecentage = new float[9] { 1f, 0.4f, 0.25f, 0.1f, 0.08f, 0.07f, 0.06f, 0.05f, 0.03f };
    private void Awake()
    {
       
    }
    private void Start()
    {
        gameEvents_.RaceStartEvent.AddListener(MakeDubut);
        gameEvents_.RaceSkillActivateEvent.AddListener(DistanceShortenBySkill);
        MainUiController.Instance.GameDataInit(ThisGameData);
    }

    public void MakeDubut()
    {
        ThisGameData.ThisRound.DebutRaceInit();
    }
    public void DistanceShortenBySkill(int skillEffect)
    {
        var nowRunDistance = ThisGameData.ThisRound.NowRace.NowRunDistance;
        ThisGameData.ThisRound.NowRace.NowRunDistance = Mathf.Clamp(nowRunDistance + skillEffect, 0, ThisGameData.ThisRound.NowRace.ThisRaceLength);
    }
    public void PassGoal()
    {
        if (ThisGameData.ThisRound.NowRace.RemainingRunDistance == 0)
        {
            //生出終點名次
        }
        else
        {
            //以榜外做收
        }
    }    
    public int GetRaceRewardPrice(int rank)
    {
        var nowRaceType = ThisGameData.ThisRound.NowRace.ThisRaceType;
        var price = Mathf.RoundToInt(raceInfos_.GetRacePrice(nowRaceType) *PricePrecentage[rank-1]);
        return  price;
    }
    
    
}
