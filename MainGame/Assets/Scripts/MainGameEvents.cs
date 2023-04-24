using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MainGameEvents
{
    public UnityEvent GameRestartEvent = new();
    public UnityEvent GameStartEvent = new();
    public UnityEvent RaceStartEvent = new UnityEvent();
    public UnityEvent<int> RaceSkillActivateEvent = new UnityEvent<int>(); 

}
