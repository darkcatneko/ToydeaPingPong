﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MainUIObject : MonoBehaviour
{
    [SerializeField] public Text NowRaceType;
    [SerializeField] public Text NowRaceRemainDistance;
    [SerializeField] public Text YourHorseHighestPossiblePlace;
    [SerializeField] public Text NowRaceCount;
    [SerializeField] public Text NowEarnedPoint;
    [SerializeField] public Text NowGameRound;
    [SerializeField] public Image BoostImage;
    [SerializeField] public GameObject BoostShadowImage;
    [Header("影片放送器")]
    [SerializeField] public VideoPlayer VideoPlayer;
    [SerializeField] public RenderTexture VideoRenderTexture;
    [SerializeField] public RawImage VideoRawImage;
    [SerializeField] public Image UpperVideoImage;
    [Header("開頭影片")]
    [SerializeField] public RawImage StartVideoRawImage;
    [Header("升階圖片")]
    [SerializeField] public GameObject InvitationRaceImageSpawnPlace;
    [SerializeField] public GameObject InvitationRaceImage;
    [Header("遊戲結束")]
    [SerializeField] public GameObject GameOverPanel;
    [Header("試合結果")]
    [SerializeField] public GameObject RaceResultImage;
    void Start()
    {
        MainUiController.Instance.MainUIOBJ = this;
    }

    
    void Update()
    {
        
    }
}
