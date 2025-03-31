using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGoal : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            int levelToUnlock = SceneManager.GetActiveScene().buildIndex - 1;
            if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCount)
            {
                PlayerPrefs.SetInt($"Level {levelToUnlock}", 1);
                PlayerPrefs.Save();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }

        }
    }
}
