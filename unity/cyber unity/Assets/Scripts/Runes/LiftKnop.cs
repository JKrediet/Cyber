using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftKnop : MonoBehaviour
{
    public GameObject deur;

    public int deurDichtGaanTijd;
    public int knipperCount;

    public GameObject lampje;
    public Material rood, wit;

    public void Knipper()
    {
        knipperCount++;
        if (knipperCount <= deurDichtGaanTijd)
        {
            LightRood();
            Invoke("LightWit", 0.5f);
            Invoke("Knipper", 1f);
        }
    }

    public void LightRood()
    {
        lampje.GetComponent<Renderer>().material = rood;
    }
    public void LightWit()
    {
        lampje.GetComponent<Renderer>().material = wit;
    }
}

