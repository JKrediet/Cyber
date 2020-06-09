using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ItemScript : MonoBehaviour
{
    public GameObject siring, potion, highLightSiring, highLightPotion;
    public int siringQuantity, potionQuantity, siringValue,potionValue;
    public Text siringText,potionText;
    public bool SiringActive, potionActive, cooldownPotion, cooldownSiring, coolDownPotion;
    public float coolDownTime;
    //siring,potion is a ui emptyobject group that puts it on or off depeding on the quantity that the mc has
    //value is a number that gives the play a sertan amount of potion/siring
    void Start()
    {
        PoitionHighLightOff();
        SiringHighLightOff();
    }
    void Update()
    {
        UIChange();
        Usedge();
        HighLight();
    }
    void OnTriggerEnter(Collider item)
    {
        if (item.gameObject.transform.tag == "Siring")
        {          
            if (siringQuantity < 3)
            {
                if (coolDownPotion == false)
                {
                    StartCoroutine(PickUpCooldown());
                    siringQuantity +=1;
                }
            }
        }
        if (item.gameObject.transform.tag == "Potion")
        {
            if (potionQuantity <  3)
            {
                if (coolDownPotion == false)
                {
                    StartCoroutine(PickUpCooldown());
                    potionQuantity +=1;
                }
            }
        }
    }

    IEnumerator Cooldown()
    {
        cooldownSiring = true;
        cooldownPotion = true;
        yield return new WaitForSeconds(coolDownTime);
        cooldownPotion = false;
        cooldownSiring = false;
    }
    public void Usedge()
    {
        if (SiringActive==true)
        {
            if (cooldownSiring == false)
            {
                 if (Input.GetButtonDown("Q"))
                 {
                 StartCoroutine(Cooldown());
                 GetComponent<Health>().health += siringValue;
                 siringQuantity -= 1;
                 }
            }
        }
        if (potionActive==true)
        {
            if (cooldownPotion == false)
            {
                if (Input.GetButtonDown("Q"))
                {
                    StartCoroutine(Cooldown());
                GetComponent<Health>().health += potionValue;
                    potionQuantity -= 1;
                }
            }
        }
    }
    void UIChange()
    {
        siringText.text = siringQuantity.ToString();
        potionText.text = potionQuantity.ToString();
        if (siringQuantity <= 0)
        {
            SiringOff();
        }
        if (siringQuantity >= 1)
        {
            SiringOn();
        }
        if (potionQuantity <= 0)
        {
            PotionOff();
        }
        if (potionQuantity >= 1)
        {
            PotionOn();
        }
    }
    public void SiringOff()
    {
        siring.SetActive(false);
    }
    public void SiringOn()
    {
        siring.SetActive(true);
    }
    public void PotionOff()
    {
        potion.SetActive(false);
    }
    public void PotionOn()
    {
        potion.SetActive(true);
    }
    public void HighLight()
    {
      
            if (Input.GetButton("1"))
            {
                SiringHighLightOff();
                PoitionHighLightOn();
                SiringActive = false;
                potionActive = true;              
            }
       
      
            if (Input.GetButton("2"))
            {
                PoitionHighLightOff();
                SiringHighLightOn();
                potionActive = false;
                SiringActive = true;
            
        }
    }
    public void SiringHighLightOff()
    {
        highLightSiring.SetActive(false);
    }
    public void PoitionHighLightOff()
    {
        highLightPotion.SetActive(false);
    }
    public void SiringHighLightOn()
    {
        highLightSiring.SetActive(true);
    }
    public void PoitionHighLightOn()
    {
        highLightPotion.SetActive(true);
    }
     IEnumerator PickUpCooldown()
    {
        coolDownPotion = true;
        yield return new WaitForSeconds(1.2f);
        coolDownPotion = false;
    }
}
