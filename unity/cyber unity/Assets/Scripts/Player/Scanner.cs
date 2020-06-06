using UnityEngine;
public class Scanner : MonoBehaviour
{
    RaycastHit hit;
    public GameObject lift;
    public Rune rune;
    public GameObject raycastpoint;

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
            // hit.transform.gameObject.GetComponent.< Rune > ();
            if (Input.GetButtonDown("Interaction"))
            {
                if (hit.transform.tag == "Rune")
                {
                    rune = hit.transform.gameObject.GetComponent<Reference>().rune;
                    print(rune.runeName);
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
        }
    }
    public void Test()
    {
        Debug.DrawRay(raycastpoint.transform.position, transform.forward, Color.red);
    }
}