using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_SkillTree : MonoBehaviour
{
    // beautiful ints
    public int maxHealthCount, maxRegenCount, maxReducedDamageCount, maxMeleeDamageCount, maxRangedDamageCount,
        maxMeleeCritChanceCount, maxMeleeCritDamageCount, maxRangedCritChanceCount, maxRangedCritDamageCount;

    // bools 2.0
    public int hR5, mR5, rR5;

    private int totalSkillpoints;
    public int skillPointAmount;
    public TextMeshProUGUI skillPointText;

    public List<int> Skill_Counter;
    public List<TextMeshProUGUI> Skill_CountText;

    // buttons
    private GameObject[] skills;

    private void Start()
    {
        skillPointAmount = PlayerPrefs.GetInt("skillPointAmount", skillPointAmount);

        hR5 = PlayerPrefs.GetInt("hR5", 0);
        mR5 = PlayerPrefs.GetInt("mR5", 0);
        rR5 = PlayerPrefs.GetInt("rR5", 0);

        maxHealthCount = PlayerPrefs.GetInt("maxHealthCount", maxHealthCount);
        maxRegenCount = PlayerPrefs.GetInt("maxRegenCount", maxRegenCount);
        maxReducedDamageCount = PlayerPrefs.GetInt("maxReducedDamageCount", maxReducedDamageCount);
        maxMeleeDamageCount = PlayerPrefs.GetInt("maxMeleeDamageCount", maxMeleeDamageCount);
        maxMeleeCritChanceCount = PlayerPrefs.GetInt("maxMeleeCritChanceCount", maxMeleeCritChanceCount);
        maxMeleeCritDamageCount = PlayerPrefs.GetInt("maxMeleeCritDamageCount", maxMeleeCritDamageCount);
        maxRangedDamageCount = PlayerPrefs.GetInt("maxRangedDamageCount", maxRangedDamageCount);
        maxRangedCritChanceCount = PlayerPrefs.GetInt("maxRangedCritChanceCount", maxRangedCritChanceCount);
        maxRangedCritDamageCount = PlayerPrefs.GetInt("maxRangedCritDamageCount", maxRangedCritDamageCount);

        // de 0/5
        Skill_Counter[0] = PlayerPrefs.GetInt("Skill_Counter" + 0, 0);
        Skill_Counter[1] = PlayerPrefs.GetInt("Skill_Counter" + 1, 0);
        Skill_Counter[2] = PlayerPrefs.GetInt("Skill_Counter" + 2, 0);
        Skill_Counter[3] = PlayerPrefs.GetInt("Skill_Counter" + 3, 0);
        Skill_Counter[4] = PlayerPrefs.GetInt("Skill_Counter" + 4, 0);
        Skill_Counter[5] = PlayerPrefs.GetInt("Skill_Counter" + 5, 0);
        Skill_Counter[6] = PlayerPrefs.GetInt("Skill_Counter" + 6, 0);
        Skill_Counter[7] = PlayerPrefs.GetInt("Skill_Counter" + 7, 0);
        Skill_Counter[8] = PlayerPrefs.GetInt("Skill_Counter" + 8, 0);

        Skill_Quantity();
        ButtonToWhite();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Interaction") || Input.GetButtonDown("Escape"))
        {
            skillPointText.text = skillPointAmount.ToString();
            Invoke("Saves_UI", 1);
        }
    }

    public void Saves_UI()
    {
        PlayerPrefs.SetInt("skillPointAmount", skillPointAmount);

        PlayerPrefs.SetInt("hR5", hR5);
        PlayerPrefs.SetInt("mR5", mR5);
        PlayerPrefs.SetInt("rR5", rR5);

        PlayerPrefs.SetInt("maxHealthCount", maxHealthCount);
        PlayerPrefs.SetInt("maxRegenCount", maxRegenCount);
        PlayerPrefs.SetInt("maxReducedDamageCount", maxReducedDamageCount);
        PlayerPrefs.SetInt("maxMeleeDamageCount", maxMeleeDamageCount);
        PlayerPrefs.SetInt("maxMeleeCritChanceCount", maxMeleeCritChanceCount);
        PlayerPrefs.SetInt("maxMeleeCritDamageCount", maxMeleeCritDamageCount);
        PlayerPrefs.SetInt("maxRangedDamageCount", maxRangedDamageCount);
        PlayerPrefs.SetInt("maxRangedCritChanceCount", maxRangedCritChanceCount);
        PlayerPrefs.SetInt("maxRangedCritDamageCount", maxRangedCritDamageCount);

        // de 0/5
        PlayerPrefs.SetInt("Skill_Counter" + 0, Skill_Counter[0]);
        PlayerPrefs.SetInt("Skill_Counter" + 1, Skill_Counter[1]);
        PlayerPrefs.SetInt("Skill_Counter" + 2, Skill_Counter[2]);
        PlayerPrefs.SetInt("Skill_Counter" + 3, Skill_Counter[3]);
        PlayerPrefs.SetInt("Skill_Counter" + 4, Skill_Counter[4]);
        PlayerPrefs.SetInt("Skill_Counter" + 5, Skill_Counter[5]);
        PlayerPrefs.SetInt("Skill_Counter" + 6, Skill_Counter[6]);
        PlayerPrefs.SetInt("Skill_Counter" + 7, Skill_Counter[7]);
        PlayerPrefs.SetInt("Skill_Counter" + 8, Skill_Counter[8]);

        PlayerPrefs.Save();
    }
    #region 0/5
    // zet de 0/5 naar 5/5
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
        totalSkillpoints += skillPoint;
        skillPointText.text = skillPointAmount.ToString();
    }

    #region buttonsToWhite
    public void ButtonToWhite()
    {
        if (hR5 == 1)
        {
            skills = GameObject.FindGameObjectsWithTag("Health Skills");

            foreach (GameObject button in skills)
            {
                button.GetComponent<Image>().color = Color.white;
            }
        }
        else
        {
            skills = GameObject.FindGameObjectsWithTag("Health Skills");

            foreach (GameObject button in skills)
            {
                button.GetComponent<Image>().color = Color.gray;
            }
        }
        if (mR5 == 1)
        {
            skills = GameObject.FindGameObjectsWithTag("Melee Skills");

            foreach (GameObject button in skills)
            {
                button.GetComponent<Image>().color = Color.white;
            }
        }
        else
        {
            skills = GameObject.FindGameObjectsWithTag("Melee Skills");

            foreach (GameObject button in skills)
            {
                button.GetComponent<Image>().color = Color.gray;
            }
        }
        if (rR5 == 1)
        {
            skills = GameObject.FindGameObjectsWithTag("Ranged Skills");

            foreach (GameObject button in skills)
            {
                button.GetComponent<Image>().color = Color.white;
            }
        }
        else
        {
            skills = GameObject.FindGameObjectsWithTag("Ranged Skills");

            foreach (GameObject button in skills)
            {
                button.GetComponent<Image>().color = Color.gray;
            }
        }
    }
    #endregion

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

                if (maxHealthCount == 5)
                {
                    hR5 = 1;
                    ButtonToWhite();
                }
            }
        }
    }
    // health regen
    public void Skill_HealthRegen()
    {
        if (hR5 == 1)
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
        if (hR5 == 1)
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
        if (skillPointAmount > 0)
        {
            if (maxMeleeDamageCount < 5)
            {
                maxMeleeDamageCount++;
                skillPointAmount--;
                Skill_Counter[3]++;
                Skill_Quantity();
                FindObjectOfType<Skills>().MeleeDamageIncrease();

                if (maxMeleeDamageCount == 5)
                {
                    mR5 = 1;
                    ButtonToWhite();
                }
            }
        }
    }
    // melee crit chance
    public void Skill_MeleeCritChance()
    {
        if (mR5 == 1)
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
        if (mR5 == 1)
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
                    rR5 = 1;
                    ButtonToWhite();
                }
            }
        }
    }
    // ranged crit chance
    public void Skill_RangedCritChance()
    {
        if (rR5 == 1)
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
        if (rR5 == 1)
        {
            if (skillPointAmount > 0)
            {
                if (maxRangedCritDamageCount < 5)
                {
                    maxRangedCritDamageCount++;
                    skillPointAmount--;
                    Skill_Counter[8]++;
                    Skill_Quantity();
                    FindObjectOfType<Skills>().RangedCritDamageIncrease();
                }
            }
        }
    }
    #endregion


    public void Reset()
    {
        maxHealthCount = 0;
        maxRegenCount = 0;
        maxReducedDamageCount = 0;
        maxMeleeDamageCount = 0;
        maxMeleeCritChanceCount = 0;
        maxMeleeCritDamageCount = 0;
        maxRangedDamageCount = 0;
        maxRangedCritChanceCount = 0;
        maxRangedCritDamageCount = 0;

        Skill_Counter[0] = 0;
        Skill_Counter[1] = 0;
        Skill_Counter[2] = 0;
        Skill_Counter[3] = 0;
        Skill_Counter[4] = 0;
        Skill_Counter[5] = 0;
        Skill_Counter[6] = 0;
        Skill_Counter[7] = 0;
        Skill_Counter[8] = 0;

        hR5 = 0;
        mR5 = 0;
        rR5 = 0;

        skillPointAmount = totalSkillpoints;
        totalSkillpoints = 0;
        ButtonToWhite();
        Skill_Quantity();
        FindObjectOfType<HealthPlayer>().Reset();
        FindObjectOfType<MeleeAttack>().Reset();
        FindObjectOfType<RangedAttack>().Reset();
        FindObjectOfType<Skills>().Reset();
    }
}
