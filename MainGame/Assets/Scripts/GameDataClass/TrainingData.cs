using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrainingData
{
    public int Speed = 90;
    public int Stamina = 90;
    public int Strength = 90;
    public int Intelligence = 90;
    [field:SerializeField]public UmaRank ThisUmaRank { get; private set; } 
    public void AddAttributes(Attributes attributes,int plusAmount )
    {
        switch (attributes)
        {
            case Attributes.Speed:
                plusSpeed(plusAmount);
                break;
            case Attributes.Stamina:
                plusStamina(plusAmount);
                break;
            case Attributes.Strength:
                plusStrength(plusAmount);
                break;
            case Attributes.Intelligence:
                plusIntelligence(plusAmount);
                break;
            default:
                break;
        }
        rankUp();
    }
    private void rankUp()
    {
        if (Speed ==300&& Stamina ==300&& Strength ==300&& Intelligence == 300)
        {
            ThisUmaRank = (UmaRank)((int)ThisUmaRank + 1);
            Speed = Stamina = Strength = Intelligence = 0;
        }      
    }

    private void plusSpeed(int plusAmount)
    {
        Speed = Mathf.Clamp(Speed + plusAmount, 0, 300);
    }
    private void plusStamina(int plusAmount)
    {
        Stamina = Mathf.Clamp(Stamina + plusAmount, 0, 300);
    }
    private void plusStrength(int plusAmount)
    {
        Strength = Mathf.Clamp(Strength + plusAmount, 0, 300);
    }
    private void plusIntelligence(int plusAmount)
    {
        Intelligence = Mathf.Clamp(Intelligence + plusAmount, 0, 300);
    }

}
public enum Attributes
{
    Speed,
    Stamina,
    Strength,
    Intelligence,
}
[System.Serializable]
public enum UmaRank { E, D, C, B, A, S, SS }