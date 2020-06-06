using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public int playerLevel, levelToGive;
    public float expPoints;


    // moet nog gedaan worden op moment van scene switching
    private void Start()
    {
        //playerLevel = PlayerPrefs.GetInt(savedLevel, 0);
    }

    private void Update()
    {
        CurrentExp(default);
        GiveLevel();
    }

    // level up
    public void CurrentExp(float f)
    {
        expPoints += f;
        //expBar.value = expPoints;
        if(expPoints >= 100)
        {
            expPoints -= 100;
            LevelUp();
            //ook geluid?
        }
    }
    public void GiveLevel()
    {
        //geeft level naar skilltree en zet skillpoint geven naar 0
        if (FindObjectOfType<UI_SkillTree>() != null)
        {
            FindObjectOfType<UI_SkillTree>().GetComponent<UI_SkillTree>().LevelUp(levelToGive);
            levelToGive = 0;
        }
    }

    // level omgoog/ skillpoint erbij
    public void LevelUp()
    {
        //geluid afspelen levelup
        levelToGive++;
        playerLevel++; //level om te laten zien in UI
    }
}
