using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : HealthTotal
{
    public float healthIncreasement, HealthRegenIncreasement, reducedDamageTakenIncreasement;
    private float baseHealth, healthRegen, baseRegen, reducedDamageTaken, baseReducedDamage;

    private void Awake()
    {
        baseHealth = totalHealth;
        baseRegen = healthRegen;
        baseReducedDamage = reducedDamageTaken;
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
    }

    public override void Health(float doDamage)
    {
        health -= doDamage - reducedDamageTaken;

        if (health <= 0)
        {
           
        }
    }

    //health regen in update
    public void HealthRegen()
    {
        health += healthRegen * Time.deltaTime;
    }
    //maybe gebruiken?
    public void UsePotion(float heal)
    {
        Mathf.Clamp(health, 0, totalHealth);
        health += heal;
    }

    #region skillnotes
    // skillpoint reward more health
    public void HealthSkillNote(float skillAmount)
    {
        float newHealth = baseHealth;
        newHealth += healthIncreasement * skillAmount;

        totalHealth = newHealth;
        health = totalHealth;

        // naar stats in skilltree sturen
        FindObjectOfType<UI_Skill_Info>().Health(totalHealth);
    }
    // skillpoint health regen
    public void HealthRegenSkillNote(float skillAmount)
    {
        float newRegen = baseRegen;
        newRegen += HealthRegenIncreasement * skillAmount;

        healthRegen = newRegen;

        // naar stats in skilltree sturen
        FindObjectOfType<UI_Skill_Info>().HRegen(healthRegen);
    }
    // skillpoint reduced damage taken
    public void ReducedDamageTakenSkillNote(float skillAmount)
    {
        float newReducedDamage = baseReducedDamage;
        newReducedDamage += reducedDamageTakenIncreasement * skillAmount;

        reducedDamageTaken = newReducedDamage;
        // naar stats in skilltree sturen
        FindObjectOfType<UI_Skill_Info>().RIDamage(reducedDamageTaken);
    }
    #endregion
}
