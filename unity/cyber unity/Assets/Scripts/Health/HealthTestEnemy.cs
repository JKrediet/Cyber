public class HealthTestEnemy : HealthTotal
{
    public float expValue;

    public override void Health(float doDamage)
    {
        health -= doDamage;

        if (health <= 0)
        {
            FindObjectOfType<Level>().CurrentExp(expValue);
           
        }
    }
}
