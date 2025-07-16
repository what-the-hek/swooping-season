using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Image[] eggs;
    public globalVariables globalVariables;

    public void UpdateEggs()
    {
        for (int i = 0; i < eggs.Length; i++)
        {
            Color eggColor = eggs[i].color;
            eggColor.a = i < globalVariables.healthScore ? 1f : 0.3f; // 1f = opaque, 0.3f = "cracked"
            eggs[i].color = eggColor;
        }
    }
}
