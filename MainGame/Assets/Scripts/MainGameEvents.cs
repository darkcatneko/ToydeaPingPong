﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MainGameEvents
{
    public UnityEvent GameRestartEvent = new();
    public UnityEvent GameStartEvent = new();
    public UnityEvent GameOverEvent = new UnityEvent();

    public UnityEvent DebutRaceStartEvent = new UnityEvent();
    public UnityEvent<RaceLength> RepeatableRaceStartEvent = new UnityEvent<RaceLength>();
    public UnityEvent PlayerRankedUpEvent = new UnityEvent();

    public UnityEvent<Attributes,int> TrainingEvent = new UnityEvent<Attributes, int>();
    public UnityEvent PlayerShouldRankUpEvent = new UnityEvent();

    public UnityEvent RaceStartEvent = new UnityEvent();

    public UnityEvent EnemyPassGoalEvent = new UnityEvent();
    public UnityEvent PlayerPassGoalEvent = new UnityEvent();

    public UnityEvent PlayerEatCarrotEvent = new UnityEvent();
    public UnityEvent PlayerFirstEnterFieldEvent = new UnityEvent();
    public UnityEvent PlayerEnterTeleporterEvent = new UnityEvent();
    
    public UnityEvent PlayerHitBounceObjectEvent = new UnityEvent();
        
}
