using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UI_Skill_Info : MonoBehaviour
{
    public TextMeshProUGUI skillInfo;
    public List<TextMeshProUGUI> statInfo;

    public string health, hRegen, rIDamage, mDamage, mCChance, mCDamage, rDamage, rCChance, rCDamage;

    public void Awake()
    {
        health = PlayerPrefs.GetString("healthStat", health);
        hRegen = PlayerPrefs.GetString("hRegenStat", hRegen);
        rIDamage = PlayerPrefs.GetString("rIDamageStat", rIDamage);

        mDamage = PlayerPrefs.GetString("mDamageStat", mDamage);
        mCChance = PlayerPrefs.GetString("MCChanceStat", mCChance);
        mCDamage = PlayerPrefs.GetString("mCDamageStat", mCDamage);

        rDamage = PlayerPrefs.GetString("rDamageStat", rDamage);
        rCChance = PlayerPrefs.GetString("rCChance", rCChance);
        rCDamage = PlayerPrefs.GetString("rCDamageStat", rCDamage);
    }

    private void Start()
    {
        Stats();
    }
    public void ChanceSkillInfo(TextMeshProUGUI t)
    {
        skillInfo.text = t.text;
        Stats();
    }
    public void Stats()
    {
        statInfo[0].text = health;
        statInfo[1].text = hRegen + "/sec";
        statInfo[2].text = rIDamage;
        statInfo[3].text = mDamage;
        statInfo[4].text = mCChance + "%";
        statInfo[5].text = mCDamage + "x";
        statInfo[6].text = rDamage;
        statInfo[7].text = rCChance + "%";
        statInfo[8].text = rCDamage + "x";
    }

    //saves
    private void Update()
    {
        Saves_Stats();
        Stats();
    }
    public void Saves_Stats()
    {
        PlayerPrefs.SetString("healthStat", health);
        PlayerPrefs.SetString("hRegenStat", hRegen);
        PlayerPrefs.SetString("rIDamageStat", rIDamage);

        PlayerPrefs.SetString("mDamageStat", mDamage);
        PlayerPrefs.SetString("MCChanceStat", mCChance);
        PlayerPrefs.SetString("mCDamageStat", mCDamage);

        PlayerPrefs.SetString("rDamageStat", rDamage);
        PlayerPrefs.SetString("rCChance", rCChance);
        PlayerPrefs.SetString("rCDamageStat", rCDamage);

        PlayerPrefs.Save();
    }

    #region Stat info binnenkrijgen
    // health
    public void Health(float f)
    {
        health = f.ToString();
        Stats();
    }
    public void HRegen(float f)
    {
        hRegen = f.ToString();
        Stats();
    }
    public void RIDamage(float f)
    {
        rIDamage = f.ToString();
        Stats();
    }

    // melee
    public void MDamage(float f)
    {
        mDamage = f.ToString();
        Stats();
    }
    public void MCChance(float f)
    {
        mCChance = f.ToString();
        Stats();
    }
    public void MCDamage(float f)
    {
        mCDamage = f.ToString();
        Stats();
    }

    // ranged
    public void RDamage(float f)
    {
        rDamage = f.ToString();
        Stats();
    }
    public void RCChance(float f)
    {
        rCChance = f.ToString();
        Stats();
    }
    public void RCDamage(float f)
    {
        rCDamage = f.ToString();
        Stats();
    }
    #endregion
}
