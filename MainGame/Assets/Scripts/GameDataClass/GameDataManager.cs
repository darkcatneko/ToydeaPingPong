using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
        gameEvents_.TrainingEvent.AddListener(umaBeTrain);
        MainUiController.Instance.GameDataInit(ThisGameData);
    }
    private void makeDubut()
    {
        ThisGameData.ThisRound.DebutRaceInit();
    }
    private void enemyPassGoal()
    {
        ThisGameData.ThisRound.NowRace.YourHorseHighestPlace++;
    }
    private void playerPassGoalGet()
    {
        ThisGameData.ThisRound.EarnedPriceMoney += GetLimitedRewardPrice(ThisGameData.ThisRound.NowRace.YourHorseHighestPlace,ThisGameData.ThisRound.ThisUmaTraingData.ThisUmaRank);
        ThisGameData.ThisRound.RaceList.Add(ThisGameData.ThisRound.NowRace);
        ThisGameData.ThisRound.NowRace = new RaceData(RaceLength.None);
        MainUiController.Instance.CallUpdateRoundInfo();
    }
    public int GetLimitedRewardPrice(int raceRank, UmaRank umaRank)
    {
        var raceRewardPrice = GetRaceRewardPrice(raceRank);
        var LimitReward = GetLimitRewardByUmaRank(raceRewardPrice, umaRank);
        return LimitReward;
    }
    public int GetRaceRewardPrice(int raceRank)
    {
        var nowRaceType = ThisGameData.ThisRound.NowRace.ThisRaceType;
        var price = Mathf.RoundToInt(raceInfos_.GetRacePrice(nowRaceType) * pricePrecentage_[raceRank - 1]);
        return price;
    }
    public int GetLimitRewardByUmaRank(int price, UmaRank umaRank)
    {
        var LimitReward = price;
        var rankLimitation = new float[7] {0.15f,0.25f, 0.4f, 0.55f, 0.7f, 0.9f, 1f };
        LimitReward = Mathf.RoundToInt( LimitReward*rankLimitation[(int)umaRank]);
        return LimitReward;
    }
    private void roundReset()
    {
        ThisGameData.RoundDatas.Add(ThisGameData.ThisRound);
        ThisGameData.ThisRound = new RoundData();
        ThisGameData.WhichRound++;
        MainUiController.Instance.CallUpdateGameDataInfo();
        MainUiController.Instance.CallUpdateTraingBoard();
    }
    private void startedANewRepeatableRace(RaceLength raceLength)
    {
        ThisGameData.ThisRound.NowRace = new RaceData(raceLength);
        ThisGameData.ThisRound.ThisUmaTraingData.EnterRaceChance--;
        if (ThisGameData.ThisRound.ThisUmaTraingData.EnterRaceChance == 0)
        {
            MainGameController.Instance.RacePointToZero();
        }
        MainUiController.Instance.CallUpdateRaceInfo();
    }
    private void umaBeTrain(Attributes attributes, int amount)
    {
        ThisGameData.ThisRound.ThisUmaTraingData.AddAttributes(attributes, amount);
        MainUiController.Instance.CallUpdateTraingBoard();
    }




}
