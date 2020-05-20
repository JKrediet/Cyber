
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    public Animator anim;

    public bool lightTrigger,buttonPressed;

    public int deurDichtGaanTijd;
    public int knipperCount;
    public int sceneInt;

    public Material red, white;
    public GameObject lightRed, LightWhite;
    public GameObject hitBox;

    public void StartLift()
    {
        buttonPressed = true;
        hitBox.SetActive(true);
    }
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

        if (buttonPressed == true)
        {
            print("ff kijken");
            lightTrigger = true;
            anim.SetInteger("Condition", 1);
            Invoke("ClosingDoors", 1f);
        }
        if (lightTrigger == true) {
            Invoke("Flash", 1f);
        }
    }
    public void ButtonPressed()
    {
        anim.SetInteger("Condition", 1);
        Invoke("ClosingDoors", 0.2f);
    }
    public void ClosingDoors()
    {
        anim.SetInteger("Condition", 2);
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
        GetComponent<SkinnedMeshRenderer>().material = red;
    }
    public void LightWit()
    {
        LightWhite.SetActive(true);
        lightRed.SetActive(false);
        GetComponent<SkinnedMeshRenderer>().material = white;
    }
    public void DoorClosed()
    {
        hitBox.SetActive(true);
        LightWhite.SetActive(true);
        lightRed.SetActive(false);
        GetComponent<SkinnedMeshRenderer>().material = white;
        SceneManager.LoadScene(sceneInt);
    }
}
