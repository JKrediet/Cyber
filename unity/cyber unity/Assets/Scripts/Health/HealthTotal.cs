using UnityEngine;

public class HealthTotal : MonoBehaviour
{
    public float health;
    public float totalHealth;

    public virtual void Health(float doDamage)
    {
        health -= doDamage;

        if(health <= 0)
        {
           
        }
    }
}
