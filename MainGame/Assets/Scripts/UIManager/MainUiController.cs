using Codice.Client.BaseCommands.BranchExplorer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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
        MainUIOBJ_.NowRaceType.text = raceData.ThisRaceType.ToString();
        MainUIOBJ_.NowRaceRemainDistance.text = raceData.ThisRaceLength.ToString();
        MainUIOBJ_.YourHorseHighestPossiblePlace.text = raceData.YourHorseHighestPlace.ToString(); 
    }
    private void updateRoundInfo(RoundData roundData)
    {
        MainUIOBJ_.NowEarnedPoint.text = roundData.EarnedPriceMoney.ToString();
    }
    public void CallUpdateRaceInfo()
    {
        updateRaceInfo(gameData_.ThisRound.NowRace);
    }
    public void CallUpdateRoundInfo()
    {
        updateRoundInfo(gameData_.ThisRound);
    }

}
