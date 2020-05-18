using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSwitcher : MonoBehaviour
{
    public GameObject rangedAttack, skillTree;
    public bool skillTreeActive;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Escape"))
        {
            if(skillTreeActive == false)
            {
                skillTreeActive = true;
            }
            else
            {
                skillTreeActive = false;
            }
            SkillTreeOn();
        }
    }

    public void SkillTreeOn()
    {
        if (skillTreeActive == true)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            rangedAttack.SetActive(false);
            skillTree.SetActive(true);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            rangedAttack.SetActive(true);
            skillTree.SetActive(false);
        }
    }
}
