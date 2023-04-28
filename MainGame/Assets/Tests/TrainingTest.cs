using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TrainingTest
{
   
    [Test]
    [TestCase(Attributes.Speed, 210, UmaRank.E )]
    public void TrainingTestSimplePasses(Attributes attributes, int plusAmount, UmaRank result)
    {
        var trainingData = new TrainingData();
        trainingData.AddAttributes(attributes, plusAmount);
        Assert.IsTrue(trainingData.ThisUmaRank == result, $"Msg");
    }
    [Test]
    [TestCase( 210, UmaRank.D)]
    public void TrainingTestRankUpTest(int plusAmount, UmaRank result)
    {
        var trainingData = new TrainingData();
        trainingData.AddAttributes(Attributes.Speed, plusAmount);
        trainingData.AddAttributes(Attributes.Strength, plusAmount);
        trainingData.AddAttributes(Attributes.Stamina, plusAmount);
        trainingData.AddAttributes(Attributes.Intelligence, plusAmount);
        Assert.IsTrue(trainingData.ThisUmaRank == result, $"Msg");
    }

}
