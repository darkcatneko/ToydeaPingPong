using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionController : MonoBehaviour
{
    [SerializeField] private Transform debutCamaraPos_;
    [SerializeField] private Transform normalCameraPos_;
    private void Start()
    {
        MainGameController.Instance.MainGameEvents_.GameRestartEvent.AddListener(changeToDebutCameraPos);
        MainGameController.Instance.MainGameEvents_.PlayerFirstEnterFieldEvent.AddListener(changeToNormalCameraPos);
    }

    private void changeToDebutCameraPos()
    {
        Camera.main.transform.position = debutCamaraPos_.position;
        Camera.main.transform.rotation = debutCamaraPos_.rotation;
    }
    private void changeToNormalCameraPos()
    {
        Camera.main.transform.position = normalCameraPos_.position;
        Camera.main.transform.rotation = normalCameraPos_.rotation;
    }
}

