using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Scanner : MonoBehaviour
{
    RaycastHit hit;
    public GameObject lift;
    public Rune rune;
    public GameObject raycastpoint;

    public Image runeText;
    public GameObject panel, pressF;

    private void Start()
    {
        raycastpoint = GameObject.FindGameObjectWithTag("raycastpoint");
    }
    void Update()
    {
        RayCast();
        Debug.DrawRay(transform.position, transform.forward, Color.red);
    }

    public void RayCast()
    {
        if (Physics.Raycast(raycastpoint.transform.position, transform.forward, out hit, 20))
        {
            if (Input.GetButtonDown("Interaction"))
            {
                if (hit.transform.tag == "Rune")
                {
                    rune = hit.transform.gameObject.GetComponent<Reference>().rune;
                    runeText.sprite = rune.runeDesc;
                    panel.SetActive(true);
                    print(rune.runeName);
                    FindObjectOfType<PanelSwitcher>().Pauze();

                    FindObjectOfType<Level>().levelToGive += rune.skillPoint;
                    hit.transform.gameObject.SetActive(false);

                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true;
                }         
            }
            Test();

            // interaction met liftknop
            if  (Input.GetButtonDown("Interaction"))
            {
                if (hit.transform.tag == "Button")
                {
                    FindObjectOfType<Elevator>().buttonPressed = true;
                }
            }

            //pressf to true/false
            if (hit.transform.tag == "Rune" || hit.transform.tag == "Button")
            {
                pressF.SetActive(true);
            }
            else
            {
                pressF.SetActive(false);
            }
        }
    }

    public void CloseWindow()
    {
        panel.SetActive(false);

        FindObjectOfType<PanelSwitcher>().Resume();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Test()
    {
        Debug.DrawRay(raycastpoint.transform.position, transform.forward, Color.red);
    }
}