using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotSpawner : MonoBehaviour
{
    [Header("一半長度")]//X軸
    [SerializeField] private float spawnerHalfLength_=10;
    [Header("一半寬度")]//Z軸
    [SerializeField] private float spawnerHalfWidth_=5;

    public void SpawnACarrotInArea(GameObject carrot)
    {
        carrot.SetActive(true);
        carrot.transform.position = getARandomCustomYPosition(carrot.transform.position.y);
    }
    private Vector3 getARandomCustomYPosition(float customY)
    {
        return new Vector3(getARandomXPOS(), customY, getARandomZPOS());
    }
    private float getARandomXPOS()
    {
        var randomX = Random.Range(-1 * spawnerHalfLength_, spawnerHalfLength_);
        var finalXPos = this.transform.position.x + randomX;
        return finalXPos;
    }
    private float getARandomZPOS()
    {
        var randomZ = Random.Range(-1 * spawnerHalfWidth_, spawnerHalfWidth_);
        var finalZPos = this.transform.position.z + randomZ;
        return finalZPos;
    }
}
