using UnityEngine;

public class PotionScript : MonoBehaviour
{
    public GameObject player;
    public int spinSpeed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnTriggerEnter(Collider item)
    {
        if (item.gameObject.transform.tag == "Player")
        {
            if (player.GetComponent<PotionUse>().potionCount < 3)
            {
                Invoke("Destroy", 0.1f);
            }
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    public void Spin()
    {
        transform.Rotate(0, 1, 0 * spinSpeed);
    }
    void Update()
    {
        Spin();
    }
}