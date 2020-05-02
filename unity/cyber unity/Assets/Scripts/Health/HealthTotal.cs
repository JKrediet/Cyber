using UnityEngine;

public class HealthTotal : MonoBehaviour
{
    public int health;

    public virtual void Health(int doDamage)
    {
        health -= doDamage;

        if(health <= 0)
        {
            Destroy(gameObject, 3f);
        }
    }
}
