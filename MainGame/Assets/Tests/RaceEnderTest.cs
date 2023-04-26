using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using static UnityEngine.Networking.UnityWebRequest;

public class RaceEnderTest
{
    
    [Test]
    [TestCase(RaceLength.Middle,2000,1,30000)]
    [TestCase(RaceLength.Middle, 2000, 9, 900)]
    public void RaceEndTest(RaceLength raceLength,int runDistance,int rank,int result)
    {
        var gameObject = new GameObject();
        var gameDataManager = gameObject.AddComponent<GameDataManager>();

        gameDataManager.ThisGameData.ThisRound = new RoundData();
        gameDataManager.ThisGameData.ThisRound.NowRace.ThisRaceType = raceLength; ;
        //gameDataManager.ThisGameData.ThisRound.NowRace.NowRunDistance = runDistance;

        var EarnPoint = gameDataManager.GetRaceRewardPrice(rank);
        Debug.Log(EarnPoint);
        Assert.IsTrue(EarnPoint == result, $"Msg");

    }

    [Test]
    public void RandomRaceTest()
    {
        bool canRaceLengthBeNone = true;
        for (int i = 0; i < 1000; i++)
        {
            var race = new RaceData();
            if (race.ThisRaceType == RaceLength.None )
            {
                canRaceLengthBeNone = false;
            }
        }
        Assert.IsTrue(canRaceLengthBeNone == true, $"Msg");
    }
}
