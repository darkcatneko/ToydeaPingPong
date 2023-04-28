using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingBoardUIObj : MonoBehaviour
{
    [SerializeField] public Sprite[] RankSpritePrefab;
    [SerializeField] public Image RankImage;
    [SerializeField] public Slider SpeedSlider;
    [SerializeField] public Slider StaminaSlider;
    [SerializeField] public Slider StrengthSlider;
    [SerializeField] public Slider IntelligenceSlider;
    void Start()
    {
        MainUiController.Instance.TrainingBoardUIObj = this;
    }
}
