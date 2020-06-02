
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    public Animator anim;
    public bool lightTrigger,buttonPressed,DeadBoss;
    public int deurDichtGaanTijd;
    public int knipperCount;
    public int sceneInt;
    public GameObject hitBox;

    private void Start()
    {       
        knipperCount = 0;
        hitBox.SetActive(false);       
        buttonPressed = false;
    }
    public void Update()
    {
        if (DeadBoss == true)
        {
            //  anim.SetInteger("Condition", 1);
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
        buttonPressed = false;
    }
    public void Flash()
    {
        knipperCount++;
        if (knipperCount <= deurDichtGaanTijd)
        {
      
           
        }
        else {
            DoorClosed();
        }
    }
    public void DoorClosed()
    {
        SceneManager.LoadScene(sceneInt);
    }
}
