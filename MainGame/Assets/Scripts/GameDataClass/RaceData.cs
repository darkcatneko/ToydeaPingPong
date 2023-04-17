using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RaceData 
{
    [SerializeField]public RaceLength ThisRaceType = RaceLength.Middle;
    public int ThisRaceLength => (int)ThisRaceLength;
}

[System.Serializable]
public enum RaceLength
{
    Short = 1200,
    Mile = 1800,
    Middle = 2200,
    Long = 2500,
    Dirt = 1600,
}
