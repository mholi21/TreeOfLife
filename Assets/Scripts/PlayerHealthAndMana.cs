using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerHealthAndMana : MonoBehaviour
{
    public float playerMaxHealth = 500;
    public float playerCurrentHealth = 0;
    public float playerMaxMana = 100;
    public float playerCurrentMana = 0;
    public Image healthBar;
    public Image manaBar;
    public bool isDead = false;

    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        playerCurrentMana = playerMaxMana;
    }

    void Update()
    {
        if (playerCurrentMana != playerMaxMana)
        {
            UpdateMana(0.05f);
        }
    }

    public void UpdateHealth(float healthUpdateValue)
    {
        if (playerCurrentHealth <= 0)
        {
            isDead = true;
            gameObject.GetComponent<Animator>().SetBool("IsDead", true);
        }

        if (!isDead)
        {
            playerCurrentHealth = Mathf.Clamp((playerCurrentHealth += healthUpdateValue), 0, playerMaxHealth);
            SetHealth(playerCurrentHealth / playerMaxHealth);
        }
    }

    public void UpdateMana(float manaUpdateValue)
    {
        if (!isDead)
        {
            playerCurrentMana = Mathf.Clamp((playerCurrentMana += manaUpdateValue), 0, playerMaxMana);
            SetHMana(playerCurrentMana / playerMaxMana);
        }
    }

    public void ChangeMaxHealth(float maxHP)
    {
        playerMaxHealth += maxHP;
        playerCurrentHealth = Mathf.Clamp(playerCurrentHealth, 0, playerMaxHealth);
        SetHealth(playerCurrentHealth / playerMaxHealth);
    }

    public void ChangeMaxMana(float maxMP)
    {
        playerMaxMana += maxMP;
        playerCurrentMana = Mathf.Clamp(playerCurrentMana, 0, playerMaxMana);
        SetHMana(playerCurrentMana / playerMaxMana);
    }

    void SetHealth(float playerHP)
    {
        healthBar.fillAmount = playerHP;
    }

    void SetHMana(float playerMP)
    {
        manaBar.fillAmount = playerMP;
    }
}
