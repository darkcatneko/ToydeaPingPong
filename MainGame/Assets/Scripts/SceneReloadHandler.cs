using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class SceneReloadHandler : MonoBehaviour
{
    private void Start()
    {
        Invoke("gameStarter", 9f);
    }
    private void gameStarter()
    {
        MainGameController.Instance.GameStart();
    }
}
