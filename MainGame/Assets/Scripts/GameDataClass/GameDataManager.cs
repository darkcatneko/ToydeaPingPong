using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public GameData ThisGameData = new GameData();
    private MainGameEvents gameEvents_ => MainGameController.Instance.MainGameEvents_;
    private RaceInfos raceInfos_ = new RaceInfos();
    private float[] pricePrecentage_ = new float[9] { 1f, 0.4f, 0.25f, 0.1f, 0.08f, 0.07f, 0.06f, 0.05f, 0.03f };
    private void Awake()
    {
       
    }
    private void Start()
    {
        gameDataInit();
    }
    private void gameDataInit()
    {
        gameEvents_.DebutRaceStartEvent.AddListener(makeDubut);
        gameEvents_.EnemyPassGoalEvent.AddListener(enemyPassGoal);
        gameEvents_.PlayerPassGoalEvent.AddListener(playerPassGoalGet);
        gameEvents_.GameRestartEvent.AddListener(roundReset);
        gameEvents_.RepeatableRaceStartEvent.AddListener(startedANewRepeatableRace);
        MainUiController.Instance.GameDataInit(ThisGameData);
    }
    private void makeDubut()
    {
        ThisGameData.ThisRound.DebutRaceInit();
    }
   private void startedANewRepeatableRace(RaceLength raceLength)
    {
        ThisGameData.ThisRound.NowRace = new RaceData(raceLength);
        MainUiController.Instance.CallUpdateRaceInfo();
    }
    private void enemyPassGoal()
    {
        ThisGameData.ThisRound.NowRace.YourHorseHighestPlace++;
    }    
    private void playerPassGoalGet()
    {
        ThisGameData.ThisRound.EarnedPriceMoney += GetRaceRewardPrice(ThisGameData.ThisRound.NowRace.YourHorseHighestPlace);        
        ThisGameData.ThisRound.RaceList.Add(ThisGameData.ThisRound.NowRace);
        MainUiController.Instance.CallUpdateRoundInfo();
    }
    public int GetRaceRewardPrice(int rank)
    {
        var nowRaceType = ThisGameData.ThisRound.NowRace.ThisRaceType;
        var price = Mathf.RoundToInt(raceInfos_.GetRacePrice(nowRaceType) *pricePrecentage_[rank-1]);
        return  price;
    }
    private void roundReset()
    {
        ThisGameData.RoundDatas.Add(ThisGameData.ThisRound);
        ThisGameData.ThisRound = new RoundData();
        ThisGameData.WhichRound++;
        MainUiController.Instance.CallUpdateGameDataInfo();
    }
    
}
