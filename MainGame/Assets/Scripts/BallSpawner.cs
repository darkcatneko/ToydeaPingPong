using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint_;
    [SerializeField] private GameObject ballPrefab_;
    private void OnEnable()
    {
        //if (MainGameController.Instance.PlayerObject == null)
        //{
        //    MainGameController.Instance.MainGameEvents_.GameStartEvent.AddListener(spawn_Ball);
        //}
    }
    private void Start()
    {
        spawn_Ball();
        MainGameController.Instance.MainGameEvents_.GameRestartEvent.AddListener(spawn_Ball);       
    }

    private void spawn_Ball()
    {
        MainGameController.Instance.PlayerObject = Instantiate<GameObject>(ballPrefab_, spawnPoint_.transform.position, Quaternion.identity);
        MainGameController.Instance.SetPlayerRigidbody();
    }
    
}
