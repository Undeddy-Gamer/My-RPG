﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

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
    

    [Header("Damage Effect Variables")]
    public Image damageImage;
    public Image deathImage;
    public Text deathText;
    public AudioClip deathClip;
    public float flashSpeed = 5;
    public Color flashColour = new Color(1, 0, 0, .2f);
    AudioSource playerAudio;
    static public bool isDead;
    bool damaged;

    [Header("Check Point")]
    public Transform curCheckPoint;

    [Header("Save")]
    public PlayerPrefsSave saveAndLoad;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();

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


        //Player is Dead
        if (curHealth <= 0 && !isDead)
        {
            Death();
        }

        //Test Damage
        if (Input.GetKeyDown(KeyCode.X))
        {
            curHealth -= 5;
            damaged = true;
        }

        
        //Player is Damaged
        if (damaged && !isDead)
        {
            damageImage.color = flashColour;
            damaged = false;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        
    }



    void Death()
    {
        // set the death flag to this funciton int's called again
        isDead = true;

        //Set the AudioSource to play the death clip
        playerAudio.clip = deathClip;
        playerAudio.Play();

        deathImage.gameObject.GetComponent<Animator>().SetTrigger("Dead");

        deathText.text = "You died, you suck!";
        Invoke("ChangeText", 6f);
        Invoke("Revive", 9f);


    }

    void ChangeText()
    {
        deathText.text = "Fine... you can have another go";
    }

    void Revive()
    {
        isDead = false;
        curHealth = maxHealth;
        curMana = maxMana;
        curStamina = maxStamina;

        //move and rotate spawn location
        this.transform.position = curCheckPoint.position;
        this.transform.rotation = curCheckPoint.rotation;
        deathImage.gameObject.GetComponent<Animator>().SetTrigger("Alive");
        deathText.text = "";

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            curCheckPoint = other.transform;
            saveAndLoad.Save();
        }
    }


}
