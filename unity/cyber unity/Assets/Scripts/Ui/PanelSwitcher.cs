using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelSwitcher : MonoBehaviour
{
    public GameObject rangedAttack, skillTree, escMenu, cameraUit, player, deathPanel;
    public bool skillTreeActive, escMenuActive, dead, cursorLos;
    public Animator anim;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cameraUit = GameObject.FindGameObjectWithTag("Camera");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(Input.GetButtonDown("Alt"))
        {
            if (cursorLos == true)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            if (cursorLos == false)
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }

        }
        if (dead == false)
        {
            if (Input.GetButtonDown("Tab"))
            {
                if (skillTreeActive == false)
                {
                    skillTreeActive = true;
                    Pauze();
                }
                else
                {
                    skillTreeActive = false;
                    Resume();
                }
                SkillTreeOn();
            }
            if (Input.GetButtonDown("Escape"))
            {
                if (escMenuActive == false)
                {
                    escMenuActive = true;
                    Pauze();
                }
                else
                {
                    escMenuActive = false;
                    Resume();
                }
                EscMenuOn();
            }
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
    public void Pauze()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemieScript>().StopAllSound();
        }
        player.GetComponent<AudioMC>().StopDaMusic();
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        escMenuActive = false;
        skillTreeActive = false;
        EscMenuOn();
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void GetMeOuttaHere()
    {
        Application.Quit();
    }
    public void Dead()  
    {
        dead = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        escMenu.SetActive(false);
        skillTree.SetActive(false);
        rangedAttack.SetActive(false);

        deathPanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
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
