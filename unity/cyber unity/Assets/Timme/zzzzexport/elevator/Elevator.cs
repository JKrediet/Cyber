
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    public Animator anim;
    public bool lightTrigger,buttonPressed,DeadBoss;
    public int deurDichtGaanTijd;
    public int sceneInt;
    public GameObject hitBox;

    private void Start()
    {       
        hitBox.SetActive(false);       
        buttonPressed = false;
    }
    public void Update()
    {
        if (DeadBoss == true)
        {
            anim.SetInteger("Condition", 1);
            hitBox.SetActive(false);
        }
        else
        {
            hitBox.SetActive(true);
        }
        if (buttonPressed==true)
        {
            if (DeadBoss == true)
            {
                print("ff kijken");
                lightTrigger = true;
                anim.SetInteger("Condition", 2);
                Invoke("ClosingDoors", 2f);
                hitBox.SetActive(true);

            }
        }
    }
    public void ButtonPressed()
    {
        anim.SetInteger("Condition", 2);
        Invoke("ClosingDoors", 0.2f);
    }
    public void ClosingDoors()
    {
        anim.SetInteger("Condition", 3);
        Invoke("DoorClosed", (deurDichtGaanTijd));
    }
    
    
    public void DoorClosed()
    {
        SceneManager.LoadScene(sceneInt);
    }
}
