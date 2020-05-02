using UnityEngine;
using UnityEngine.UI;

public class RangedAttack : MonoBehaviour
{
    public Rigidbody arrow;
    public Slider aimPowerSlider;

    private float arrowPower;
    public float aimPower;


    private void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (Input.GetButton("Fire2"))
        {
            if (arrowPower <= 100)
            {
                arrowPower += aimPower * Time.deltaTime;
                aimPowerSlider.value = arrowPower;
            }
            else
            {
                arrowPower = 100;
            }
        }
        if(Input.GetButtonUp("Fire2"))
        {
            Rigidbody clone;
            clone = Instantiate(arrow, transform.position + transform.forward, transform.rotation);
            clone.velocity = transform.TransformDirection(Vector3.forward * arrowPower);
            arrowPower = 0;
            aimPowerSlider.value = arrowPower;
        }
    }
}
