using UnityEngine;
public class Scanner : MonoBehaviour
{
    RaycastHit hit;
    public GameObject lift;
    public Rune rune;

    void Update()
    {
        RayCast();
        Debug.DrawRay(transform.position, transform.forward, Color.red);
    }

    public void RayCast()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 20))
        {
            // hit.transform.gameObject.GetComponent.< Rune > ();
            if (hit.transform.tag == "Rune")
            {
                if (Input.GetButtonDown("Interaction"))
                {
                    rune = hit.transform.gameObject.GetComponent<Reference>().rune;
                    print(rune.runeName);
                    print(rune.runeDesc);
                    print(rune.runeObject);
                }
            }

            // interaction met liftknop
            if (hit.transform.tag == "Lift Knop")
            {

                if (Input.GetButtonDown("Interaction"))
                {
                    // lift<Elevator>().ButtonPressed
                }

            }
        }
    }
}