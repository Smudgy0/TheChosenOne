using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int maximum;
    public int current;
    float fillAmount;
    public Image mask;
    public PlayerMovement PM;

    void Update()
    {
        maximum = PM.MaxHP;
        current = PM.HP;

        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
    }
}
