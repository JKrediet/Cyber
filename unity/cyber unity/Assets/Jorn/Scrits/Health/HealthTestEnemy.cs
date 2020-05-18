public class HealthTestEnemy : HealthTotal
{
    public float expValue;

    public override void Health(float doDamage)
    {
        health -= doDamage;

        if (health <= 0)
        {
            FindObjectOfType<Level>().CurrentExp(expValue);
            gameObject.SetActive(false); //enemy uit zetten op moment na dood / moet nog naar alleen collider
            Destroy(gameObject, 3f);
        }
    }
}
