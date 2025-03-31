using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public int whatSceneToLoad = 0;

    public void Start()
    {
        Time.timeScale = 1;
    }

    public void NewGameButton()
    {
        SceneManager.LoadScene(2);
    }

    public void LevelSelectButton()
    {
        SceneManager.LoadScene(1);
    }
}
