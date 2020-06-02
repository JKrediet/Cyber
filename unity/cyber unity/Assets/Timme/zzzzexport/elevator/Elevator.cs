
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
    public GameObject lightRed, LightWhite;
    public GameObject hitBox;

    private void Start()
    {
        lightRed.SetActive(false);
        knipperCount = 0;
        hitBox.SetActive(false);
        lightTrigger = false;
        buttonPressed = false;
    }
    public void Update()
    {
        if (DeadBoss == true)
        {
            anim.SetInteger("Condition", 1);
        }
        if (buttonPressed==true)
        {
            print("ff kijken");
            lightTrigger = true;
            anim.SetInteger("Condition", 2);
            Invoke("ClosingDoors", 2f);
        }
        if (lightTrigger == true) {
            Invoke("Flash", 3f);
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
            LightRood();
           
        }
        else {
            DoorClosed();
        }
    }

    public void LightRood()
    {
        LightWhite.SetActive(false);
        lightRed.SetActive(true);
    }
    public void LightWit()
    {
        LightWhite.SetActive(true);
        lightRed.SetActive(false);
    }
    public void DoorClosed()
    {
        hitBox.SetActive(true);
        LightWhite.SetActive(true);
        lightRed.SetActive(false);
        SceneManager.LoadScene(sceneInt);
    }
}
