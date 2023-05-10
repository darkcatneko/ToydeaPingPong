//using Codice.Client.BaseCommands.BranchExplorer;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MainUiController : ToSingletonMonoBehavior<MainUiController>
{
    public MainUIObject MainUIOBJ;
    public TrainingBoardUIObj TrainingBoardUIObj;
    private GameData gameData_ = new GameData();
    private void Start()
    {
        MainGameController.Instance.MainGameEvents_.DebutRaceStartEvent.AddListener(CallPlayDebutVideo);
        MainGameController.Instance.MainGameEvents_.PlayerShouldRankUpEvent.AddListener(moveInvitationImage);
        MainGameController.Instance.MainGameEvents_.PlayerRankedUpEvent.AddListener(returnInvitationImage);
        MainGameController.Instance.MainGameEvents_.GameStartEvent.AddListener(fadeStartVideoRawImage);
        MainGameController.Instance.MainGameEvents_.GameOverEvent.AddListener(returnInvitationImage);
        MainGameController.Instance.MainGameEvents_.GameOverEvent.AddListener(callGameOverBoard);
        MainGameController.Instance.MainGameEvents_.GameRestartEvent.AddListener(turnOffGameOverBoard);
        MainGameController.Instance.MainGameEvents_.PlayerPassGoalEvent.AddListener(callRaceResultImage);
    }
    private void Update()
    {
        boostUpdate();
        if (Input.GetKeyDown(KeyCode.N))
        {
            CallPlayDebutVideo();
        }
    }
    private void boostUpdate()
    {
        MainUIOBJ.BoostImage.fillAmount = MainGameController.Instance.BallLauncher.NowPercentage;
        if (MainGameController.Instance.BallLauncher.NowPercentage == 1 && MainUIOBJ.BoostShadowImage.activeSelf ==false)
        {
            MainUIOBJ.BoostShadowImage.SetActive(true);
        }
        else if (MainGameController.Instance.BallLauncher.NowPercentage == 0)
        {
            MainUIOBJ.BoostShadowImage.SetActive(false);
        }
    }
    

    public void GameDataInit(GameData gameData)
    {
        gameData_ = gameData;
        CallUpdateTraingBoard();
    }
    #region RaceAndRoundData
    public void CallUpdateRaceInfo()
    {
        updateRaceInfo(gameData_.ThisRound.NowRace);
    }
    public void CallUpdateRoundInfo()
    {
        CallUpdateRaceInfo();
        updateRoundInfo(gameData_.ThisRound);
    }
    public void CallUpdateGameDataInfo()
    {
        CallUpdateRoundInfo();
        updateGameInfo(gameData_);
    }
    private void updateRaceInfo(RaceData raceData)
    {       
        MainUIOBJ.NowRaceType.text = "NowRaceType: "+ raceData.ThisRaceType.ToString();
        MainUIOBJ.NowRaceRemainDistance.text = "NowRaceRemainDistance: " +raceData.ThisRaceLength.ToString();
        MainUIOBJ.YourHorseHighestPossiblePlace.text = "YourHorseHighestPossiblePlace: "+ raceData.YourHorseHighestPlace.ToString(); 
        
    }
    private void updateRoundInfo(RoundData roundData)
    {
        MainUIOBJ.NowEarnedPoint.text = "NowEarnedPoint: "+ roundData.EarnedPriceMoney.ToString();
        MainUIOBJ.NowRaceCount.text = "NowRaceCount: "+ roundData.RaceList.Count.ToString();
    }
    private void updateGameInfo(GameData gameData)
    {
        MainUIOBJ.NowGameRound.text = "NowGameRound: "+gameData.WhichRound.ToString();
    }
    #endregion
    public void CallUpdateTraingBoard()
    {
        TrainingBoardUIObj.SpeedSlider.value = gameData_.GetTrainingPercentage(Attributes.Speed);
        TrainingBoardUIObj.StaminaSlider.value = gameData_.GetTrainingPercentage(Attributes.Stamina);
        TrainingBoardUIObj.StrengthSlider.value = gameData_.GetTrainingPercentage(Attributes.Strength);
        TrainingBoardUIObj.IntelligenceSlider.value = gameData_.GetTrainingPercentage(Attributes.Intelligence);
        TrainingBoardUIObj.RankImage.sprite = TrainingBoardUIObj.RankSpritePrefab[(int)gameData_.ThisRound.ThisUmaTraingData.ThisUmaRank];
    }
    public void CallPlayDebutVideo()
    {
        clearOutRenderTexture(MainUIOBJ.VideoRenderTexture);
        MainUIOBJ.UpperVideoImage.enabled = false;
        MainUIOBJ.VideoRawImage.enabled = true;
        MainUIOBJ.VideoRawImage.color = new Color(1, 1, 1, 1);
        MainUIOBJ.VideoPlayer.Play();
        Invoke("fadeDebutRawImage", 0.35f);
        Invoke("closeDebutRawImage", 0.6f);
    }
    private void clearOutRenderTexture(RenderTexture renderTexture)
    {
        RenderTexture rt = RenderTexture.active;
        RenderTexture.active = renderTexture;
        GL.Clear(true, true, Color.clear);
        RenderTexture.active = rt;
    }
    private void closeDebutRawImage()
    {
        MainUIOBJ.VideoRawImage.enabled = false;
    }
    private void fadeDebutRawImage()
    {
        MainUIOBJ.VideoRawImage.CrossFadeAlpha(0, 0.25f,true);
    }
    private void racePreparation()
    {
        MainUIOBJ.UpperVideoImage.enabled = true;
    }
    private void fadeStartVideoRawImage()
    {
        MainUIOBJ.StartVideoRawImage.CrossFadeAlpha(0, 0.25f, true);
    }
    private void moveInvitationImage()
    {
        MainUIOBJ.InvitationRaceImage.SetActive(true);
        var imageBehavior = MainUIOBJ.InvitationRaceImage.GetComponent<InvitationImageBehavior>();
        imageBehavior.MoveThisImage();
    }
    private void returnInvitationImage()
    {
        MainUIOBJ.InvitationRaceImage.SetActive(false);
        MainUIOBJ.InvitationRaceImage.transform.position = MainUIOBJ.InvitationRaceImageSpawnPlace.transform.position;
    }
    private void callGameOverBoard()
    {
        MainUIOBJ.GameOverPanel.SetActive(true);
    }
    private void turnOffGameOverBoard()
    {
        MainUIOBJ.GameOverPanel.SetActive(false);
    }
    private void callRaceResultImage()
    {
        MainUIOBJ.RaceResultImage.GetComponent<RaceResultImageBehavior>().CallResultImage(gameData_.ThisRound.NowRace.YourHorseHighestPlace);
    }
}
