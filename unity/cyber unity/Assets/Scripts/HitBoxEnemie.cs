using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxEnemie : MonoBehaviour
{
    public GameObject enemie;


    // Update is called once per frame
    void Update()
    {
        
    }
     public void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.transform.tag == "Player")
        {
            if (enemie.GetComponent<EnemieScript>().isDeath == false)
            {
                enemie.GetComponent<EnemieScript>().playerInRange = true;
                enemie.GetComponent<EnemieScript>().walking = true;
            }
        }
    }
    public void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.transform.tag == "Player")
        {
            if (enemie.GetComponent<EnemieScript>().isDeath == false)
            {
                enemie.GetComponent<EnemieScript>().playerInRange = false;
                enemie.GetComponent<EnemieScript>().walking = false;
            }
        }
    }
}
