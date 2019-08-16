using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    [Header("Value Variables")]
    public float curHealth;
    public float curMana, curStamina;
    public float maxHealth, maxMana, maxStamina;

    private float prevHealth, prevMana, prevStamina;

    [Header("Refrence Variables")]
    public Slider healthBar;
    public Slider manaBar, staminaBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(healthBar.value != curHealth/maxHealth)
        {
            curHealth = Mathf.Clamp(curHealth, 0, maxHealth);
            healthBar.value = Mathf.Clamp01(curHealth / maxHealth);
        }

        if (manaBar.value != curMana / maxMana)
        {
            curMana = Mathf.Clamp(curMana, 0, maxMana);
            manaBar.value = Mathf.Clamp01(curMana / maxMana);
        }

        if (staminaBar.value != curStamina / maxStamina)
        {
            curStamina = Mathf.Clamp(curStamina, 0, maxStamina);
            staminaBar.value = Mathf.Clamp01(curStamina / maxStamina);
        }
        
    }
}
