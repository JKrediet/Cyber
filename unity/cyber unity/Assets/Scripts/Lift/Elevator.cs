using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    public Animator anim;
    public bool lightTrigger,buttonPressed,DeadBoss,button_sound,door_sound;
    public int deurDichtGaanTijd;
    public int sceneInt;
    public GameObject hitBox,buttonElevator_sound, doorsElevator_sound;

    public GameObject saveSkilltree;

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
                lightTrigger = true;
                ButtonPressed();
                Invoke("ClosingDoors", 1f);
               // Invoke("SaveThemAll", 3f);
                hitBox.SetActive(true);
            }
        }
    }
    public void ButtonPressed()
    {
        if (button_sound == false)
        {
            buttonElevator_sound.GetComponent<AudioSource>().Play();
            button_sound = true;
        }
        anim.SetInteger("Condition", 2);
        Invoke("ClosingDoors", 0.2f);

    }
    public void ClosingDoors()
    {
        if (door_sound == false)
        {
            doorsElevator_sound.GetComponent<AudioSource>().Play();
            door_sound = true;
        }
        anim.SetInteger("Condition", 3);
        Invoke("DoorClosed", deurDichtGaanTijd);
    }
    public void SaveThemAll()
    {
        saveSkilltree.SetActive(true);
    }
    
    public void DoorClosed()
    {
        SceneManager.LoadScene(sceneInt);
    }
}
