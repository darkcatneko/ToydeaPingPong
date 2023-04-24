using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class SceneReloadHandler : MonoBehaviour
{
    
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneReload;
    }
    private void Start()
    {
        //SceneManager.sceneLoaded += OnSceneReload;
    }

    public void OnSceneReload(Scene scene, LoadSceneMode mode)
    {
        //MainGameController.Instance.GameStart();
        //Debug.Log("startscene");
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneReload;
    }
}
