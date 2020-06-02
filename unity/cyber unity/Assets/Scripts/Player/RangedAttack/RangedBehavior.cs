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
            col.gameObject.GetComponent<HealthTestEnemy>().Health(givenDamage);
        }
        if (col.gameObject.tag != "Player")
        {
            transform.parent = col.transform;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Collider>().enabled = false;
            Destroy(this, 10);
        }
    }
}
