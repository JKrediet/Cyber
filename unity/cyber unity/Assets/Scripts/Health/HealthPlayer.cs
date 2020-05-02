using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : HealthTotal
{
    public override void Health(int doDamage)
    {
        health -= doDamage;

        if (health <= 0)
        {
            Destroy(gameObject, 3f);
        }
    }
}
