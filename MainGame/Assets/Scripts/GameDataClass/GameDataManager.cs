using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public GameData ThisGameData = new GameData();
    private MainGameEvents gameEvents => MainGameController.Instance.MainGameEvents_;
    private void Start()
    {
        //MainGameController.Instance.ListenEvent(GameEvent.RaceStart, MakeDubut);
        gameEvents.RaceStartEvent.AddListener(MakeDubut);
        gameEvents.RaceSkillActivateEvent.AddListener(DistanceShortenBySkill);
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
