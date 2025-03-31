using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public bool[] LevelsUnlocked;
    public GameObject[] LevelButtons;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Created Save") == 1)
        {
            LoadSave();
        }
        else
        {
            ResetSave();
        }

    }

    public void OnLevelLoad_Button(string LevelToLoad)
    {
        SceneManager.LoadScene(LevelToLoad);
    }

    public void LoadSave()
    {
        for (int i = 1; i < LevelsUnlocked.Length; i++)
        {
            if (PlayerPrefs.GetInt($"Level {i}") != 0)
            {
                Debug.Log(i);
                LevelsUnlocked[i] = true;
                LevelButtons[i].SetActive(LevelsUnlocked[i]);
            }
        }
    }

    public void ResetSave()
    {
        PlayerPrefs.SetInt("Created Save", 1);
        for (int i = 1; i < LevelsUnlocked.Length; i++)
        {
            LevelsUnlocked[i] = false;
            LevelButtons[i].SetActive(false);
            PlayerPrefs.SetInt($"Level {i}", 0);
        }
        PlayerPrefs.Save();
    }
}
