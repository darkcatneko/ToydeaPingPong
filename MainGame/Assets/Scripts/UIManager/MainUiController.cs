using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUiController : ToSingletonMonoBehavior<MainUiController>
{
    [SerializeField] private Text NowRaceType;
    [SerializeField] private Text NowRaceRemainDistance;
    [SerializeField] private Text NowRaceCount;
    [SerializeField] private Text NowEarnedPoint;
    [SerializeField] private Text NowGameRound;

    public void UpdateRaceInfo(RaceData raceData)
    {
        NowRaceType.text = raceData.ThisRaceType.ToString();
        NowRaceRemainDistance.text = raceData.RemainingRunDistance.ToString();
    }

}
