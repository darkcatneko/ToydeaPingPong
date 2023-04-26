using Codice.Client.BaseCommands.BranchExplorer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.UI;

public class MainUiController : ToSingletonMonoBehavior<MainUiController>
{
    public MainUIObject MainUIOBJ_;
    private GameData gameData_ = new GameData();
    public void GameDataInit(GameData gameData)
    {
        gameData_ = gameData;
    }
    private void updateRaceInfo(RaceData raceData)
    {       
        MainUIOBJ_.NowRaceType.text = "NowRaceType: "+ raceData.ThisRaceType.ToString();
        MainUIOBJ_.NowRaceRemainDistance.text = "NowRaceRemainDistance: " +raceData.ThisRaceLength.ToString();
        MainUIOBJ_.YourHorseHighestPossiblePlace.text = "YourHorseHighestPossiblePlace: "+ raceData.YourHorseHighestPlace.ToString(); 
        
    }
    private void updateRoundInfo(RoundData roundData)
    {
        MainUIOBJ_.NowEarnedPoint.text = "NowEarnedPoint: "+ roundData.EarnedPriceMoney.ToString();
        MainUIOBJ_.NowRaceCount.text = "NowRaceCount: "+ roundData.RaceList.Count.ToString();
    }
    private void updateGameInfo(GameData gameData)
    {
        MainUIOBJ_.NowGameRound.text = "NowGameRound: "+gameData.WhichRound.ToString();
    }
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
}
