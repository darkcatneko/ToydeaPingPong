using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using AccelZoneNamespace;

public class AccelZoneTest
{
    // A Test behaves as an ordinary method
    [Test]
    [TestCase(20,30)]
    [TestCase(2000, 2000)]
    [TestCase(1, 20)]
    public void SpeedBoostTest(float nowSpeed,float result)
    {
        var gameobject = new GameObject();
        var accelZone = gameobject.AddComponent<AccelerationZone>();
        var speedAfterBoost = accelZone.GetSpeedAfterBoost(nowSpeed);
        Assert.That(speedAfterBoost, Is.EqualTo(result));
    }

    
}
