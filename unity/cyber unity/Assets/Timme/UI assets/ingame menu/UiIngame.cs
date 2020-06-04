using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiIngame : MonoBehaviour
{
    public bool inGameActive;
    public GameObject inGame, inGameMenu;
    void Update()
    {
        if (Input.GetButtonDown("Escape"))
        {
            if (inGameActive == false)
            {
                inGame.gameObject.SetActive(true);
                inGameMenu.gameObject.SetActive(false);
                inGameActive = true;
            }
            else
            {
                inGameMenu.gameObject.SetActive(true);
                inGame.gameObject.SetActive(false);
                inGameActive = false;
            }
      
        }
    }

    private void Start()
    {
        inGameMenu.gameObject.SetActive(false);
    }
}
