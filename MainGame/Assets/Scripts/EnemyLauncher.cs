using PlasticGui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLauncher : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyObjects;
    private List<Vector3> SpawnPosition = new List<Vector3>();
    [SerializeField] private float launchForce_ = 5000f;

    private void Start()
    {
        MainGameController.Instance.MainGameEvents_.RaceStartEvent.AddListener(launchEnemy);
        MainGameController.Instance.MainGameEvents_.PlayerPassGoalEvent.AddListener(raceEndTeleportAllEnemyToVoid);
        MainGameController.Instance.MainGameEvents_.PlayerPassGoalEvent.AddListener(replaceEnemyToStartPoint);
        for (int i = 0; i < enemyObjects.Length; i++)
        {
            SpawnPosition.Add(enemyObjects[i].transform.position);
        }
    }
    private void launchEnemy()
    {
        for (int i = 0; i < enemyObjects.Length; i++)
        {
            var randomForce = Random.Range(0, 500f);
            enemyObjects[i].GetComponent<Rigidbody>().AddForce(Vector3.forward*(launchForce_+randomForce));
        }
    }
    private void raceEndTeleportAllEnemyToVoid()
    {
        for (int i = 0; i < enemyObjects.Length; i++)
        {
            enemyObjects[i].transform.position = new Vector3(1000f, 1000f, 1000f);
        }
    }
    private void replaceEnemyToStartPoint()
    {
        for (int i = 0; i < enemyObjects.Length; i++)
        {
            enemyObjects[i].transform.position = SpawnPosition[i];
            enemyObjects[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
