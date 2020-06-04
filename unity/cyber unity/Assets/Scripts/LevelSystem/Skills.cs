using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skills : MonoBehaviour
{
    public List<int> skillsEnabled;

    // moet private worden met even veel slots als skillsEnabled
    public List<int> skillPointCount;

    private void Awake()
    {
        skillsEnabled[0] = PlayerPrefs.GetInt("skillsEnabled" + 0, 0);
        skillsEnabled[1] = PlayerPrefs.GetInt("skillsEnabled" + 1, 0);
        skillsEnabled[2] = PlayerPrefs.GetInt("skillsEnabled" + 2, 0);
        skillsEnabled[3] = PlayerPrefs.GetInt("skillsEnabled" + 3, 0);
        skillsEnabled[4] = PlayerPrefs.GetInt("skillsEnabled" + 4, 0);
        skillsEnabled[5] = PlayerPrefs.GetInt("skillsEnabled" + 5, 0);
        skillsEnabled[6] = PlayerPrefs.GetInt("skillsEnabled" + 6, 0);
        skillsEnabled[7] = PlayerPrefs.GetInt("skillsEnabled" + 7, 0);
        skillsEnabled[8] = PlayerPrefs.GetInt("skillsEnabled" + 8, 0);


        skillPointCount[0] = PlayerPrefs.GetInt("skillPointCount" + 0, 0);
        skillPointCount[1] = PlayerPrefs.GetInt("skillPointCount" + 1, 0);
        skillPointCount[2] = PlayerPrefs.GetInt("skillPointCount" + 2, 0);
        skillPointCount[3] = PlayerPrefs.GetInt("skillPointCount" + 3, 0);
        skillPointCount[4] = PlayerPrefs.GetInt("skillPointCount" + 4, 0);
        skillPointCount[5] = PlayerPrefs.GetInt("skillPointCount" + 5, 0);
        skillPointCount[6] = PlayerPrefs.GetInt("skillPointCount" + 6, 0);
        skillPointCount[7] = PlayerPrefs.GetInt("skillPointCount" + 7, 0);
        skillPointCount[8] = PlayerPrefs.GetInt("skillPointCount" + 8, 0);

        Repeat();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Interaction") || Input.GetButtonDown("Tab") || Input.GetButtonDown("Escape"))
        {
            Saves_Skills();
        }
    }

    public void Saves_Skills()
    {
        PlayerPrefs.SetInt("skillsEnabled" + 0, skillsEnabled[0]);
        PlayerPrefs.SetInt("skillsEnabled" + 1, skillsEnabled[1]);
        PlayerPrefs.SetInt("skillsEnabled" + 2, skillsEnabled[2]);
        PlayerPrefs.SetInt("skillsEnabled" + 3, skillsEnabled[3]);
        PlayerPrefs.SetInt("skillsEnabled" + 4, skillsEnabled[4]);
        PlayerPrefs.SetInt("skillsEnabled" + 5, skillsEnabled[5]);
        PlayerPrefs.SetInt("skillsEnabled" + 6, skillsEnabled[6]);
        PlayerPrefs.SetInt("skillsEnabled" + 7, skillsEnabled[7]);
        PlayerPrefs.SetInt("skillsEnabled" + 8, skillsEnabled[8]);

        PlayerPrefs.SetInt("skillPointCount" + 0, skillPointCount[0]);
        PlayerPrefs.SetInt("skillPointCount" + 1, skillPointCount[1]);
        PlayerPrefs.SetInt("skillPointCount" + 2, skillPointCount[2]);
        PlayerPrefs.SetInt("skillPointCount" + 3, skillPointCount[3]);
        PlayerPrefs.SetInt("skillPointCount" + 4, skillPointCount[4]);
        PlayerPrefs.SetInt("skillPointCount" + 5, skillPointCount[5]);
        PlayerPrefs.SetInt("skillPointCount" + 6, skillPointCount[6]);
        PlayerPrefs.SetInt("skillPointCount" + 7, skillPointCount[7]);
        PlayerPrefs.SetInt("skillPointCount" + 8, skillPointCount[8]);

        PlayerPrefs.Save();
    }
    private void Repeat()
    {
        SetSkillToTrue();
        Invoke("Repeat", 1);
    }

    #region skillnote to true/amount
    //public void skillName()
    public void MoreHp()
    {
        skillPointCount[0]++;
        skillsEnabled[0] = 1;
        SetSkillToTrue();
    }
    public void HealthRegen()
    {
        skillPointCount[1]++;
        skillsEnabled[1] = 1;
        SetSkillToTrue();
    }
    public void ReducedDamageTaken()
    {
        skillPointCount[2]++;
        skillsEnabled[2] = 1;
        SetSkillToTrue();
    }
    public void MeleeDamageIncrease()
    {
        skillPointCount[3]++;
        skillsEnabled[3] = 1;
        SetSkillToTrue();
    }
    public void MeleeCritChanceIncrease()
    {
        skillPointCount[4]++;
        skillsEnabled[4] = 1;
        SetSkillToTrue();
    }
    public void MeleeCritDamageIncrease()
    {
        skillPointCount[5]++;
        skillsEnabled[5] = 1;
        SetSkillToTrue();
    }
    public void RangedDamageIncrease()
    {
        skillPointCount[6]++;
        skillsEnabled[6] = 1;
        SetSkillToTrue();
    }
    public void RangedCritChanceIncrease()
    {
        skillPointCount[7]++;
        skillsEnabled[7] = 1;
        SetSkillToTrue();
    }
    public void RangedCritDamageIncrease()
    {
        skillPointCount[8]++;
        skillsEnabled[8] = 1;
        SetSkillToTrue();
    }
    #endregion
    #region skills doorgeven
    //skill door voeren
    private void SetSkillToTrue()
    {
        if (skillsEnabled[0] == 1)
        {
            // health 
            FindObjectOfType<HealthPlayer>().HealthSkillNote(skillPointCount[0]);
        }
        if (skillsEnabled[1] == 1)
        {
            // health regen
            FindObjectOfType<HealthPlayer>().HealthRegenSkillNote(skillPointCount[1]);
        }
        if (skillsEnabled[2] == 1)
        {
            // reduced damage taken
            FindObjectOfType<HealthPlayer>().ReducedDamageTakenSkillNote(skillPointCount[2]);
        }
        if (skillsEnabled[3] == 1)
        {
            // melee damage 
            FindObjectOfType<MeleeAttack>().MeleeDamageSkillnote(skillPointCount[3]);
        }
        if (skillsEnabled[4] == 1)
        {
            // melee crit chace 
            FindObjectOfType<MeleeAttack>().MeleeCritChanceSkillnote(skillPointCount[4]);
        }
        if (skillsEnabled[5] == 1)
        {
            // melee crit damage 
            FindObjectOfType<MeleeAttack>().MeleeCritDamageSkillnote(skillPointCount[5]);
        }
        if (skillsEnabled[6] == 1)
        {
            // ranged damage 
            FindObjectOfType<RangedAttack>().RangedDamageSkillnote(skillPointCount[6]);
        }
        if (skillsEnabled[7] == 1)
        {
            // ranged crit chance 
            FindObjectOfType<RangedAttack>().RangedCritChanceSkillnote(skillPointCount[7]);
        }
        if (skillsEnabled[8] == 1)
        {
            // ranged crit damage 
            FindObjectOfType<RangedAttack>().RangedCritDamageSkillnote(skillPointCount[8]);
        }
    }
    #endregion

    public void Reset()
    {
        skillsEnabled[0] = 0;
        skillsEnabled[1] = 0;
        skillsEnabled[2] = 0;
        skillsEnabled[3] = 0;
        skillsEnabled[4] = 0;
        skillsEnabled[5] = 0;
        skillsEnabled[6] = 0;
        skillsEnabled[7] = 0;
        skillsEnabled[8] = 0;

        skillPointCount[0] = 0;
        skillPointCount[1] = 0;
        skillPointCount[2] = 0;
        skillPointCount[3] = 0;
        skillPointCount[4] = 0;
        skillPointCount[5] = 0;
        skillPointCount[6] = 0;
        skillPointCount[7] = 0;
        skillPointCount[8] = 0;

        Saves_Skills();
    }
}
