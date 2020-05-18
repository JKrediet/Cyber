using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UI_SkillTree : MonoBehaviour
{
    // beautiful ints
    private int maxHealthCount, maxRegenCount, maxReducedDamageCount, maxMeleeDamageCount, maxRangedDamageCount,
        maxMeleeCritChanceCount, maxMeleeCritDamageCount, maxRangedCritChanceCount, maxRangedDamageChanceCount;

    private bool hR5, mR5, rR5;


    public int skillPointAmount;
    public TextMeshProUGUI skillPointText;

    public List<int> Skill_Counter;
    public List<TextMeshProUGUI> Skill_CountText;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            skillPointText.text = skillPointAmount.ToString();
        }
    }
    #region 0/5
    // zet de 0/5 naar 1/5
    public void Skill_Quantity()
    {
        Skill_CountText[0].text = Skill_Counter[0].ToString() + "/5";
        Skill_CountText[1].text = Skill_Counter[1].ToString() + "/5";
        Skill_CountText[2].text = Skill_Counter[2].ToString() + "/5";
        Skill_CountText[3].text = Skill_Counter[3].ToString() + "/5";
        Skill_CountText[4].text = Skill_Counter[4].ToString() + "/5";
        Skill_CountText[5].text = Skill_Counter[5].ToString() + "/5";
        Skill_CountText[6].text = Skill_Counter[6].ToString() + "/5";
        Skill_CountText[7].text = Skill_Counter[7].ToString() + "/5";
        Skill_CountText[8].text = Skill_Counter[8].ToString() + "/5";

    }
    #endregion

    // krijgt skillpoints binnen
    public void LevelUp(int skillPoint)
    {
        skillPointAmount += skillPoint;
        skillPointText.text = skillPointAmount.ToString();
    }
    
    #region health skillnotes
    // health
    public void Skill_Health()
    {
        if (skillPointAmount > 0)
        {
            if (maxHealthCount < 5)
            {
                maxHealthCount++;
                skillPointAmount--;
                Skill_Counter[0]++;
                Skill_Quantity();
                FindObjectOfType<Skills>().MoreHp();

                if(maxHealthCount == 5)
                {
                    hR5 = true;
                }
            }
        }
    }
    // health regen
    public void Skill_HealthRegen()
    {
        if (hR5 == true)
        {
            if (skillPointAmount > 0)
            {
                if (maxRegenCount < 5)
                {
                    maxRegenCount++;
                    skillPointAmount--;
                    Skill_Counter[1]++;
                    Skill_Quantity();
                    FindObjectOfType<Skills>().HealthRegen();
                }
            }
        }
    }
    // reduced damage taken
    public void Skill_ReducedDamageTaken()
    {
        if (hR5 == true)
        {
            if (skillPointAmount > 0)
            {
                if (maxReducedDamageCount < 5)
                {
                    maxReducedDamageCount++;
                    skillPointAmount--;
                    Skill_Counter[2]++;
                    Skill_Quantity();
                    FindObjectOfType<Skills>().ReducedDamageTaken();
                }
            }
        }
    }
    #endregion
    #region melee skillnotes
    // melee damage
    public void Skill_MeleeDamage()
    {
        if(skillPointAmount > 0)
        {
            if(maxMeleeDamageCount < 5)
            {
                maxMeleeDamageCount++;
                skillPointAmount--;
                Skill_Counter[3]++;
                Skill_Quantity();
                FindObjectOfType<Skills>().MeleeDamageIncrease();

                if (maxMeleeDamageCount == 5)
                {
                    mR5 = true;
                }
            }
        }
    }
    // melee crit chance
    public void Skill_MeleeCritChance()
    {
        if (mR5 == true)
        {
            if (skillPointAmount > 0)
            {
                if (maxMeleeCritChanceCount < 5)
                {
                    maxMeleeCritChanceCount++;
                    skillPointAmount--;
                    Skill_Counter[4]++;
                    Skill_Quantity();
                    FindObjectOfType<Skills>().MeleeCritChanceIncrease();
                }
            }
        }
    }
    // melee crit damage
    public void Skill_MeleeCritDamage()
    {
        if (mR5 == true)
        {
            if (skillPointAmount > 0)
            {
                if (maxMeleeCritDamageCount < 5)
                {
                    maxMeleeCritDamageCount++;
                    skillPointAmount--;
                    Skill_Counter[5]++;
                    Skill_Quantity();
                    FindObjectOfType<Skills>().MeleeCritDamageIncrease();
                }
            }
        }
    }
    #endregion
    #region ranged skillnotes
    // ranged damage
    public void Skill_RangedDamage()
    {
        if (skillPointAmount > 0)
        {
            if (maxRangedDamageCount < 5)
            {
                maxRangedDamageCount++;
                skillPointAmount--;
                Skill_Counter[6]++;
                Skill_Quantity();
                FindObjectOfType<Skills>().RangedDamageIncrease();

                if (maxRangedDamageCount == 5)
                {
                    rR5 = true;
                }
            }
        }
    }
    // ranged crit chance
    public void Skill_RangedCritChance()
    {
        if (rR5 == true)
        {
            if (skillPointAmount > 0)
            {
                if (maxRangedCritChanceCount < 5)
                {
                    maxRangedCritChanceCount++;
                    skillPointAmount--;
                    Skill_Counter[7]++;
                    Skill_Quantity();
                    FindObjectOfType<Skills>().RangedCritChanceIncrease();
                }
            }
        }
    }
    // ranged crit damage
    public void Skill_RangedCritDamage()
    {
        if (rR5 == true)
        {
            if (skillPointAmount > 0)
            {
                if (maxRangedDamageChanceCount < 5)
                {
                    maxRangedDamageChanceCount++;
                    skillPointAmount--;
                    Skill_Counter[8]++;
                    Skill_Quantity();
                    FindObjectOfType<Skills>().RangedCritDamageIncrease();
                }
            }
        }
    }
    #endregion
}
