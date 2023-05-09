using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpawnerTester
{    
    [Test]
    public void SpawnerTesterSimplePasses()
    {
        var objectCenter = new Vector3(10, 0, 5);
        var gameobject = new GameObject();
        gameobject.transform.position = objectCenter;
        var spawner = gameobject.AddComponent<CarrotSpawner>();
        var testGameobject = new GameObject();
        var result = true;
        for (int i = 0; i < 1000; i++)
        {
            spawner.SpawnACarrotInArea(testGameobject);
            if (testGameobject.transform.position.x>20|| testGameobject.transform.position.x < 0||testGameobject.transform.position.z > 10 || testGameobject.transform.position.z < 0)
            {
                result = false;
            }
        }
        Assert.IsTrue(result == true, $"Msg");
    }


}
