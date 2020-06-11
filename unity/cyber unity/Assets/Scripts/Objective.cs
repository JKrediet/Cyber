using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Poefweg", 5);
    }

    void Poefweg()
    {
        gameObject.SetActive(false);
    }
}
