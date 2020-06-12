using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOutsideMap : MonoBehaviour
{

    public void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.transform.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
