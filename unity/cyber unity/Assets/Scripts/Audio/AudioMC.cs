using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMC : MonoBehaviour
{
    public GameObject running, idle, bow_aiming, bow_release, melee_attack1, melee_attack2, gettingHit, buttonPressed, zoof;

    public void Sound_running()
    {
        StopDaMusic();
        running.GetComponent<AudioSource>().Play();
    }
    public void Bow_aiming()
    {
        StopDaMusic();
        bow_aiming.GetComponent<AudioSource>().Play();
    }
    public void Melee_attack1()
    {
        StopDaMusic();
        melee_attack1.GetComponent<AudioSource>().Play();
    }
    public void Melee_attack2()
    {
        StopDaMusic();
        melee_attack2.GetComponent<AudioSource>().Play();
    }
    public void GettingHit()
    {
        StopDaMusic();
        gettingHit.GetComponent<AudioSource>().Play();
    }
    public void Bow_release()
    {
        StopDaMusic();
        bow_release.GetComponent<AudioSource>().Play();
    }
    public void ButtonPressed()
    {
        StopDaMusic();
        buttonPressed.GetComponent<AudioSource>().Play();
    }
    public void Zoof()
    {
        StopDaMusic();
        zoof.GetComponent<AudioSource>().Play();
    }

    public void StopDaMusic()
    {
        running.GetComponent<AudioSource>().Stop();
        idle.GetComponent<AudioSource>().Stop();
        bow_aiming.GetComponent<AudioSource>().Stop();
        bow_release.GetComponent<AudioSource>().Stop();
        melee_attack1.GetComponent<AudioSource>().Stop();
        melee_attack2.GetComponent<AudioSource>().Stop();
        gettingHit.GetComponent<AudioSource>().Stop();
        buttonPressed.GetComponent<AudioSource>().Stop();
    }
}
