using UnityEngine;
using UnityEngine.UI;

public class RaidialHealth : MonoBehaviour
{

    public float currHealth, maxHealth;
    public Image radialHealthIcon;


    void HealthChange()
    {
        float amount = Mathf.Clamp01(currHealth/maxHealth);
        radialHealthIcon.fillAmount = amount;
    }

    // Update is called once per frame
    void Update()
    {
        HealthChange();
    }
}
