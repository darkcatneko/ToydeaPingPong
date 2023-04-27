using System;

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class RaceData 
{
    [SerializeField]
    public RaceLength ThisRaceType = RaceLength.None;
    public int ThisRaceLength => (int)ThisRaceType;

    public int YourHorseHighestPlace = 1;

    public RaceData()
    {
        ThisRaceType = getRandomRaceLength();
    }
    public RaceData(RaceLength raceLength)
    {
        ThisRaceType = raceLength;
    }
    private RaceLength getRandomRaceLength()
    {
        RaceLength[] raceLengths = (RaceLength[])Enum.GetValues(typeof(RaceLength));
        System.Random random = new System.Random();
        var randomNum = random.Next(raceLengths.Length);
        while (raceLengths[randomNum] == RaceLength.None)
        {
            randomNum = random.Next(raceLengths.Length);
        }
        RaceLength randomRaceLength = raceLengths[randomNum];
        return randomRaceLength;
    }
}

[Serializable]
public enum RaceLength
{
    Short = 1200,
    Mile = 1800,
    Middle = 2000,
    Long = 2500,
    Dirt = 1600,
    None = 0,
}
