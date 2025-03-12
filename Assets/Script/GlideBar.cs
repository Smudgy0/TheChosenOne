using UnityEngine;
using UnityEngine.UI;

public class GlideBar : MonoBehaviour
{
    public float maximum;
    public float current;
    float fillAmount;
    public Image mask;
    public PlayerMovement PM;

    void Update()
    {
        maximum = PM.MaxGlideDuration;
        current = PM.GlideDuration;

        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
    }
}
