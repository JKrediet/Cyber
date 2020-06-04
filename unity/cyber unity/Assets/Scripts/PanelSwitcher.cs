using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSwitcher : MonoBehaviour
{
    public GameObject rangedAttack, skillTree, escMenu;
    public bool skillTreeActive, escMenuActive;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Tab"))
        {
            if (skillTreeActive == false)
            {
                skillTreeActive = true;
            }
            else
            {
                skillTreeActive = false;
            }
            SkillTreeOn();
        }
        if (Input.GetButtonDown("Escape"))
        {
            if (escMenuActive == false)
            {
                escMenuActive = true;
            }
            else
            {
                escMenuActive = false;
            }
            EscMenuOn();
        }
    }
    #region escMenuOn
    public void EscMenuOn()
    {
        if (escMenuActive == true)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            rangedAttack.SetActive(false);
            skillTree.SetActive(false);
            escMenu.SetActive(true);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            rangedAttack.SetActive(true);
            skillTree.SetActive(false);
            escMenu.SetActive(false);
        }
    }
    #endregion
    #region SkillTreeOn
    public void SkillTreeOn()
    {
        if (skillTreeActive == true)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            rangedAttack.SetActive(false);
            skillTree.SetActive(true);
            escMenu.SetActive(false);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            rangedAttack.SetActive(true);
            skillTree.SetActive(false);
            escMenu.SetActive(false);
        }
    }
    #endregion
}
