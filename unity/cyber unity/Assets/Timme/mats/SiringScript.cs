using UnityEngine;

public class SiringScript : MonoBehaviour
{
    public GameObject player;
    public int spinSpeed;
    void Update()
    {
        Spin();
    }
    void OnTriggerEnter(Collider item)
    {
        if (item.gameObject.transform.tag == "Player")
        {
            if (player.GetComponent<ItemScript>().siringQuantity<3)
            {
                Invoke("Destroy",1f);
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
}