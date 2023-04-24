using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RaceEnderTest
{
    
    [Test]
    [TestCase(RaceLength.Middle,2000,1,300000000)]
    public void RaceEndTest(RaceLength raceLength,int runDistance,int rank,int result)
    {
        var gameObject = new GameObject();
        var gameDataManager = gameObject.AddComponent<GameDataManager>();

        gameDataManager.ThisGameData.ThisRound = new RoundData();
        gameDataManager.ThisGameData.ThisRound.NowRace.ThisRaceType = raceLength; ;
        gameDataManager.ThisGameData.ThisRound.NowRace.NowRunDistance = runDistance;

        var EarnPoint = gameDataManager.GetRaceRewardPrice(rank);
        Debug.Log(EarnPoint);
        Assert.IsTrue(EarnPoint == result, $"Msg");

    }
}
