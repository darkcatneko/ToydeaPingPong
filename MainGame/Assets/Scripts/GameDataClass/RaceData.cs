using System;

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[System.Serializable]
public class RaceData 
{
    [SerializeField]
    public RaceLength ThisRaceType = RaceLength.Middle;
    public int ThisRaceLength => (int)ThisRaceType;

    public int NowRunDistance;

    public int RemainingRunDistance => ThisRaceLength - NowRunDistance;

    public RaceData()
    {
        ThisRaceType = getRandomRaceLength();
        NowRunDistance = 0;
    }
    public RaceData(RaceLength raceLength)
    {
        ThisRaceType = raceLength;
        NowRunDistance = 0;
    }
    private RaceLength getRandomRaceLength()
    {
        RaceLength[] raceLengths = (RaceLength[])Enum.GetValues(typeof(RaceLength));
        System.Random random = new System.Random();
        RaceLength randomRaceLength = raceLengths[random.Next(raceLengths.Length)];
        return randomRaceLength;
    }
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
