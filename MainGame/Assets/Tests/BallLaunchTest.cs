using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using PinBallNamespace;

public class BallLaunchTest
{
    // A Test behaves as an ordinary method
    [Test]
    [TestCase(2,3,2)]
    [TestCase(4.999f,5,5)]
    [TestCase(5, 5, 5)]
    public void LauncherTest(float nowTime, float chargeUsedTime,float result)
    {
        var testobj = new GameObject();
        var ballLauncher = testobj.AddComponent<BallLauncher>();
        var actualOutputForce = ballLauncher.AddTime(nowTime,chargeUsedTime);
        if (nowTime + Time.deltaTime >= chargeUsedTime)
        {
            Assert.That(actualOutputForce, Is.EqualTo(result));
        }
        else 
        {
            Assert.That(actualOutputForce, Is.EqualTo(nowTime + Time.deltaTime));
        }    
        
    }
    
}

