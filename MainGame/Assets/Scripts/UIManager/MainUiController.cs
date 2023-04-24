using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUiController : ToSingletonMonoBehavior<MainUiController>
{
    public MainUIObject MainUIOBJ_;

    public void UpdateRaceInfo(RaceData raceData)
    {
        MainUIOBJ_.NowRaceType.text = raceData.ThisRaceType.ToString();
        MainUIOBJ_.NowRaceRemainDistance.text = raceData.RemainingRunDistance.ToString();
    }

}
