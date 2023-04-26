using PlasticGui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLauncher : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyObjects_;
    private List<Vector3> spawnPositions_ = new List<Vector3>();
    [SerializeField] private float launchForce_ = 5000f;

    private void Start()
    {
        enemyLauncherEventInit();
        getAllEnemyObjectPosition();
    }
    private void enemyLauncherEventInit()
    {

        MainGameController.Instance.MainGameEvents_.RaceStartEvent.AddListener(launchEnemy);
        MainGameController.Instance.MainGameEvents_.PlayerPassGoalEvent.AddListener(raceEndTeleportAllEnemyToVoid);
        MainGameController.Instance.MainGameEvents_.PlayerPassGoalEvent.AddListener(replaceEnemyToStartPoint);
        
    }
    private void getAllEnemyObjectPosition()
    {
        for (int i = 0; i < enemyObjects_.Length; i++)
        {
            spawnPositions_.Add(enemyObjects_[i].transform.position);
        }
    }
    private void launchEnemy()
    {
        for (int i = 0; i < enemyObjects_.Length; i++)
        {
            var randomForce = Random.Range(0, 500f);
            enemyObjects_[i].GetComponent<Rigidbody>().AddForce(Vector3.forward*(launchForce_+randomForce));
        }
    }
    private void raceEndTeleportAllEnemyToVoid()
    {
        for (int i = 0; i < enemyObjects_.Length; i++)
        {
            enemyObjects_[i].transform.position = new Vector3(1000f, 1000f, 1000f);
        }
    }
    private void replaceEnemyToStartPoint()
    {
        for (int i = 0; i < enemyObjects_.Length; i++)
        {
            enemyObjects_[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            enemyObjects_[i].transform.position = spawnPositions_[i];           
        }
    }
}
