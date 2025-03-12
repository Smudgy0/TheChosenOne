using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject HPButton;
    public int Score;

    public TMP_Text coinCounterText;
    public TMP_Text shopErrorMessageText;

    public PlayerMovement PM;

    private void Update()
    {
        Score = PM.PlayerScore;
        UpdateCoinText(Score);
    }

    public void UpdateCoinText(int amount)
    {
        coinCounterText.SetText(Score.ToString());
    }

    public void ShopOpen()
    {
        shopUI.SetActive(true);
    }

    public void ShopClose()
    {
        shopUI.SetActive(false);
    }

    public void IncreaseHP()
    {
        if(PM.MaxHP < 6)
        {
            if(PM.PlayerScore >= 1)
            {
                PM.MaxHP = PM.MaxHP + 1;
                PM.HP = PM.HP + 1;
                PM.PlayerScore = PM.PlayerScore - 1;
                shopErrorMessageText.text = "Thank You For Your Purchase";
            }
            else
            {
                shopErrorMessageText.text = "You Cannot Affort This";
            }
            if(PM.HP >= 6)
            {
                HPButton.SetActive(false);
            }
        }
        else
        {
            shopErrorMessageText.text = "This Shop Is Out Of Stock";
        }
    }
}
