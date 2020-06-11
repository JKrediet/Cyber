using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthPlayer : HealthTotal
{
    public float healthIncreasement, HealthRegenIncreasement, reducedDamageTakenIncreasement;
    private float baseHealth, healthRegen, baseRegen, reducedDamageTaken, baseReducedDamage;

    public Slider healthSlider;

    private void Awake()
    {
        baseHealth = totalHealth;
        baseRegen = healthRegen;
        baseReducedDamage = reducedDamageTaken;
        Invoke("HealthGoedZetten", 1f);
    }

    private void Update()
    {
        if (healthRegen > 0)
        {
            if (health < totalHealth)
            {
                HealthRegen();
            }
        }
        healthSlider.value = health;
        healthSlider.maxValue = totalHealth;
    }

    public override void Health(float doDamage)
    {
        health -= doDamage - reducedDamageTaken;

        if (health <= 0)
        {
            //hier moet deathpanel!
            FindObjectOfType<PanelSwitcher>().Dead();
            gameObject.SetActive(false);
        }
    }

    //health regen in update
    public void HealthRegen()
    {
        health = Mathf.Clamp(health, 0, totalHealth);
        health += healthRegen * Time.deltaTime;
    }
    //maybe gebruiken?
    public void UsePotion(float heal)
    {
        health = Mathf.Clamp(health, 0, totalHealth);
        health += heal;
    }
    #region skillnotes
    // skillpoint reward more health
    public void HealthSkillNote(float skillAmount)
    {
        float newHealth = baseHealth;
        newHealth += healthIncreasement * skillAmount;

        totalHealth = newHealth;

        // naar stats in skilltree sturen
        StuurHealth();
    }
    // skillpoint health regen
    public void HealthRegenSkillNote(float skillAmount)
    {
        float newRegen = baseRegen;
        newRegen += HealthRegenIncreasement * skillAmount;

        healthRegen = newRegen;

        // naar stats in skilltree sturen
        StuurRegen();
    }
    // skillpoint reduced damage taken
    public void ReducedDamageTakenSkillNote(float skillAmount)
    {
        float newReducedDamage = baseReducedDamage;
        newReducedDamage += reducedDamageTakenIncreasement * skillAmount;

        reducedDamageTaken = newReducedDamage;
        // naar stats in skilltree sturen
        StuurReduction();
    }
    #endregion

    public void HealthGoedZetten()
    {
        health = totalHealth;
    }

    public void Reset()
    {
        HealthSkillNote(default);
        HealthRegenSkillNote(default);
        ReducedDamageTakenSkillNote(default);
    }

    public void StuurHealth()
    {
        if (FindObjectOfType<UI_Skill_Info>() != null)
        {
            FindObjectOfType<UI_Skill_Info>().Health(totalHealth);
        }
        else
        {
            Invoke("StuurHealth", 0.01f);
        }
    }
    public void StuurRegen()
    {
        if (FindObjectOfType<UI_Skill_Info>() != null)
        {
            FindObjectOfType<UI_Skill_Info>().HRegen(healthRegen);
        }
        else
        {
            Invoke("StuurRegen", 0.01f);
        }
    }
    public void StuurReduction()
    {
        if (FindObjectOfType<UI_Skill_Info>() != null)
        {
            FindObjectOfType<UI_Skill_Info>().RIDamage(reducedDamageTaken);
        }
        else
        {
            Invoke("StuurReduction", 0.01f);
        }
    }
}
