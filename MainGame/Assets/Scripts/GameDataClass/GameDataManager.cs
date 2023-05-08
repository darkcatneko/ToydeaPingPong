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
    private int[] trainingPointPercentage = new int[9] { 300, 250, 200, 100, 80, 60, 40, 20, 10 };
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
        gameEvents_.PlayerPassGoalEvent.AddListener(playerPassGoalGetTrainingPoint);
        gameEvents_.GameRestartEvent.AddListener(roundReset);
        gameEvents_.RepeatableRaceStartEvent.AddListener(startedANewRepeatableRace);
        gameEvents_.TrainingEvent.AddListener(umaBeTrain);
        gameEvents_.PlayerRankedUpEvent.AddListener(umaRankUp);
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
    private void playerPassGoalGetTrainingPoint()
    {
        var trainingPoint = GetTrainingPointByRaceRank(ThisGameData.ThisRound.NowRace.YourHorseHighestPlace);
        ThisGameData.ThisRound.ThisUmaTraingData.AddAttributes(Attributes.Speed, trainingPoint);
        ThisGameData.ThisRound.ThisUmaTraingData.AddAttributes(Attributes.Stamina, trainingPoint);
        ThisGameData.ThisRound.ThisUmaTraingData.AddAttributes(Attributes.Strength, trainingPoint);
        ThisGameData.ThisRound.ThisUmaTraingData.AddAttributes(Attributes.Intelligence, trainingPoint);
        MainUiController.Instance.CallUpdateTraingBoard();
    }

    private int GetTrainingPointByRaceRank(int raceRank)
    {
        var trainingPoint = trainingPointPercentage[raceRank-1];
        return trainingPoint;
    }
    #region 玩家獲取金錢
    private void playerPassGoalGetMoney()
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
    #endregion
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
        ThisGameData.ThisRound.ThisUmaTraingData.CanEnterBonusStage = false; ;
        MainGameController.Instance.PlayerRankedUp();
        MainUiController.Instance.CallUpdateRaceInfo();
    }
    private void umaBeTrain(Attributes attributes, int amount)
    {
        ThisGameData.ThisRound.ThisUmaTraingData.AddAttributes(attributes, amount);
        MainUiController.Instance.CallUpdateTraingBoard();
    }
    private void umaRankUp()
    {
        ThisGameData.ThisRound.ThisUmaTraingData.RankUp();
        MainUiController.Instance.CallUpdateTraingBoard();
    }



}
