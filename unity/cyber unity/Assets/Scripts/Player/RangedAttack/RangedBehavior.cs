using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBehavior : MonoBehaviour
{
    public float givenDamage;

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<HealthTotal>().Health(givenDamage);
        }
        if (col.gameObject.tag != "Player")
        {
            transform.parent = col.transform;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<Collider>().enabled = false;
        }
    }
}
