using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public int Score;

    public TMP_Text coinCounterText;

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
}
