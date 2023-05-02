using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MainGameEvents
{
    public UnityEvent GameRestartEvent = new();
    public UnityEvent GameStartEvent = new();

    public UnityEvent DebutRaceStartEvent = new UnityEvent();
    public UnityEvent<RaceLength> RepeatableRaceStartEvent = new UnityEvent<RaceLength>();
    public UnityEvent RacePointToZeroEvent = new UnityEvent();

    public UnityEvent<Attributes,int> TrainingEvent = new UnityEvent<Attributes, int>();
    public UnityEvent PlayerRankUpEvent = new UnityEvent();

    public UnityEvent RaceStartEvent = new UnityEvent();

    public UnityEvent EnemyPassGoalEvent = new UnityEvent();
    public UnityEvent PlayerPassGoalEvent = new UnityEvent();


    public UnityEvent PlayerFirstEnterFieldEvent = new UnityEvent();
    public UnityEvent PlayerEnterTeleporterEvent = new UnityEvent();
    
}
