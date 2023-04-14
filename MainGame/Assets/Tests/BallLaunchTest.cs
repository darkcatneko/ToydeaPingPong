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
    [TestCase(2,3,2, false)]
    [TestCase(4.999f,5,5,true)]
    [TestCase(5, 5, 5,true)]
    public void LauncherTest(float nowTime_, float chargeUsedTime_,float result,bool isOverTime_)
    {
        var testobj_ = new GameObject();
        var ballLauncher = testobj_.AddComponent<BallLauncher>();
        var actualOutputForce_ = ballLauncher.AddTime(nowTime_,chargeUsedTime_);
        if (isOverTime_)
        {
            Assert.That(actualOutputForce_, Is.EqualTo(result));
        }
        else 
        {
            Assert.That(actualOutputForce_, Is.EqualTo(nowTime_ + Time.deltaTime));
        }    
        
    }
    
}

