using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mc : MonoBehaviour
    
{
    public GameObject bowSign,bow,arrow,sword;
    public bool bowb, bowsinb, arrowb, swordb;

    void Start()
    {
        GetGameObjects();
    }
    void Update()
    {
        GameobjectChange();
    }
    public void GetGameObjects()
    {
        bowSign=GameObject.FindGameObjectWithTag("aim hud");
        bow = GameObject.FindGameObjectWithTag("bow");
        arrow = GameObject.FindGameObjectWithTag("arrow");
        sword = GameObject.FindGameObjectWithTag("sword");
    }
    public void GameobjectChange()
    {
        if (bowb == true)
        {
            bow.gameObject.SetActive(true);
        }
        else
        {
            bow.gameObject.SetActive(false);
        }
        if (bowsinb == true)
        {
            bowSign.gameObject.SetActive(true);
        }
        else
        {
            bowSign.gameObject.SetActive(false);
        }
        if (swordb == true)
        {
            sword.gameObject.SetActive(true);
        }
        else
        {
            sword.gameObject.SetActive(false);
        }
        if (arrowb == true)
        {
            arrow.gameObject.SetActive(true);
        }
        else
        {
            arrow.gameObject.SetActive(false);
        }
    }
}
