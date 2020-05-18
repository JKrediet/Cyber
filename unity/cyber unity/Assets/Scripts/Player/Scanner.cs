using UnityEngine;
public class Scanner : MonoBehaviour
{
    private bool inLift = false;
    RaycastHit hit;

    public Rune rune;

    void Update()
    {
        RayCast();
        ShowRuneInfo();

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
                if (inLift == true)
                {
                    if (Input.GetButtonDown("Interaction"))
                    {
                        //speel animatie af
                        //scene switch
                        //lighting
                      
                    }
                }
            }
        }
    }
    private void OnTriggerEnter(Collider liftCollider)
    {
        if (liftCollider.gameObject.tag == "Lift")
        {
            inLift = true;
        }
    }
    private void OnTriggerExit(Collider liftCollider)
    {
        if (liftCollider.gameObject.tag == "Lift")
        {
            inLift = false;
        }
    }


    public void ShowRuneInfo()
    {
        // show hiero de info van rune
        // en dat je hiero je skill point display rechts boven ofz krijgt
    }
}