using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public List<bool> skillsEnabled;

    // moet private worden met even veel slots als skillsEnabled
    public List<int> skillPointCount;

    private void Awake()
    {
        SetSkillToTrue();
    }

    #region skillnote to true/amount
    //public void skillName()
    public void MoreHp()
    {
        skillPointCount[0]++;
        skillsEnabled[0] = true;
        SetSkillToTrue();
    }
    public void HealthRegen()
    {
        skillPointCount[1]++;
        skillsEnabled[1] = true;
        SetSkillToTrue();
    }
    public void ReducedDamageTaken()
    {
        skillPointCount[2]++;
        skillsEnabled[2] = true;
        SetSkillToTrue();
    }
    public void MeleeDamageIncrease()
    {
        skillPointCount[3]++;
        skillsEnabled[3] = true;
        SetSkillToTrue();
    }
    public void MeleeCritChanceIncrease()
    {
        skillPointCount[4]++;
        skillsEnabled[4] = true;
        SetSkillToTrue();
    }
    public void MeleeCritDamageIncrease()
    {
        skillPointCount[5]++;
        skillsEnabled[5] = true;
        SetSkillToTrue();
    }
    public void RangedDamageIncrease()
    {
        skillPointCount[6]++;
        skillsEnabled[6] = true;
        SetSkillToTrue();
    }
    public void RangedCritChanceIncrease()
    {
        skillPointCount[7]++;
        skillsEnabled[7] = true;
        SetSkillToTrue();
    }
    public void RangedCritDamageIncrease()
    {
        skillPointCount[8]++;
        skillsEnabled[8] = true;
        SetSkillToTrue();
    }
    #endregion
    #region skills doorgeven
    //skill door voeren
    private void SetSkillToTrue()
    {
        if(skillsEnabled[0] == true)
        {
            // health 
            FindObjectOfType<HealthPlayer>().HealthSkillNote(skillPointCount[0]);
        }
        if (skillsEnabled[1] == true)
        {
            // health regen
            FindObjectOfType<HealthPlayer>().HealthRegenSkillNote(skillPointCount[1]);
        }
        if (skillsEnabled[2] == true)
        {
            // reduced damage taken
            FindObjectOfType<HealthPlayer>().ReducedDamageTakenSkillNote(skillPointCount[2]);
        }
        if (skillsEnabled[3] == true)
        {
            // melee damage 
            FindObjectOfType<MeleeAttack>().MeleeDamageSkillnote(skillPointCount[3]);
        }
        if (skillsEnabled[4] == true)
        {
            // melee crit chace 
            FindObjectOfType<MeleeAttack>().MeleeCritChanceSkillnote(skillPointCount[4]);
        }
        if (skillsEnabled[5] == true)
        {
            // melee crit damage 
            FindObjectOfType<MeleeAttack>().MeleeCritDamageSkillnote(skillPointCount[5]);
        }
        if (skillsEnabled[6] == true)
        {
            // ranged damage 
            FindObjectOfType<RangedAttack>().RangedDamageSkillnote(skillPointCount[6]);
        }
        if (skillsEnabled[7] == true)
        {
            // ranged crit chance 
            FindObjectOfType<RangedAttack>().RangedCritChanceSkillnote(skillPointCount[7]);
        }
        if (skillsEnabled[8] == true)
        {
            // ranged crit damage 
            FindObjectOfType<RangedAttack>().RangedCritDamageSkillnote(skillPointCount[8]);
        }
    }
    #endregion
}
