using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{ 
    public GameObject deur;
    public bool lightTrigger;

    public int deurDichtGaanTijd;
    public int knipperCount;

    public GameObject lampje;
    public Material rood, wit;

    private void Start()
    {
        deur.SetActive(false);
        knipperCount = 0;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lift")
        {
            deur.SetActive(true);
            Invoke("LightWit", deurDichtGaanTijd);
        }
    }
    //public void Knipper()
    //{
    //    knipperCount++;
    //    if(knipperCount <= deurDichtGaanTijd)
    //    {
    //        LightRood();
    //        Invoke("LightWit", 0.5f);
    //        Invoke("Knipper", 1f);
    //    }
    //}

    //public void LightRood()
    //{
    //    lampje.GetComponent<Renderer>().material = rood;
    //}
    //public void LightWit()
    //{
    //    lampje.GetComponent<Renderer>().material = wit;
    //}
}
