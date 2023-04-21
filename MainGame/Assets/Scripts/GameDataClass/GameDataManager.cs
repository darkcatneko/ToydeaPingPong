using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public GameData ThisGameData = new GameData();
    private void Start()
    {
        //MainGameController.Instance.ListenEvent(GameEvent.RaceStart, MakeDubut);
        MainGameController.Instance.MainGameEvents_.RaceStartEvent.AddListener(MakeDubut);
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
}
