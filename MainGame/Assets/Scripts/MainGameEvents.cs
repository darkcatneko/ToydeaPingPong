using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 事件參數的基底蕾別
/// </summary>
public class EventMessageBase
{

}

public class GameStartEventMSg : EventMessageBase
{
    public int Seond;
}

public class EmptyMsg : EventMessageBase
{

}

public class HitPillarMsg : EventMessageBase
{
    public int Distance;
}

public class MainGameEvents
{
    public UnityEvent GameRestartEvent = new();
    public UnityEvent GameStartEvent = new();
    public UnityEvent RaceStartEvent = new UnityEvent();
    public UnityEvent RaceSkillActivateEvent = new UnityEvent();        

}
