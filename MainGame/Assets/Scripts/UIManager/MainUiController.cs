using Codice.Client.BaseCommands.BranchExplorer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.UI;

public class MainUiController : ToSingletonMonoBehavior<MainUiController>
{
    public MainUIObject MainUIOBJ;
    public TrainingBoardUIObj TrainingBoardUIObj;
    private GameData gameData_ = new GameData();
    public void GameDataInit(GameData gameData)
    {
        gameData_ = gameData;
    }
    #region RaceAndRoundData
    public void CallUpdateRaceInfo()
    {
        updateRaceInfo(gameData_.ThisRound.NowRace);
    }
    public void CallUpdateRoundInfo()
    {
        CallUpdateRaceInfo();
        updateRoundInfo(gameData_.ThisRound);
    }
    public void CallUpdateGameDataInfo()
    {
        CallUpdateRoundInfo();
        updateGameInfo(gameData_);
    }
    private void updateRaceInfo(RaceData raceData)
    {       
        MainUIOBJ.NowRaceType.text = "NowRaceType: "+ raceData.ThisRaceType.ToString();
        MainUIOBJ.NowRaceRemainDistance.text = "NowRaceRemainDistance: " +raceData.ThisRaceLength.ToString();
        MainUIOBJ.YourHorseHighestPossiblePlace.text = "YourHorseHighestPossiblePlace: "+ raceData.YourHorseHighestPlace.ToString(); 
        
    }
    private void updateRoundInfo(RoundData roundData)
    {
        MainUIOBJ.NowEarnedPoint.text = "NowEarnedPoint: "+ roundData.EarnedPriceMoney.ToString();
        MainUIOBJ.NowRaceCount.text = "NowRaceCount: "+ roundData.RaceList.Count.ToString();
    }
    private void updateGameInfo(GameData gameData)
    {
        MainUIOBJ.NowGameRound.text = "NowGameRound: "+gameData.WhichRound.ToString();
    }
    #endregion
}
