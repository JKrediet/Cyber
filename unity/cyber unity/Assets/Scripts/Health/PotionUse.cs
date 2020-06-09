using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PotionUse : MonoBehaviour
{
    public int potionCount;
    public TextMeshProUGUI potionCountText;

    private void Awake()
    {
        potionCount = PlayerPrefs.GetInt("potionCount", 0);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Potion")
        {
            if (potionCount < 3)
            {
                potionCount++;
                print("Potion");
            }
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("Q"))
        {
            if (potionCount > 0)
            {
                if (GetComponent<HealthPlayer>().health < GetComponent<HealthPlayer>().totalHealth)
                {
                    potionCount--;
                    FindObjectOfType<HealthPlayer>().UsePotion(50);
                }
            }
        }
        potionCountText.text = potionCount.ToString();

        if (Input.GetButtonDown("Interaction") || Input.GetButtonDown("Tab") || Input.GetButtonDown("Escape"))
        {
            Saves_Skills();
        }
    }
    public void Saves_Skills()
    {
        PlayerPrefs.SetInt("potionCount", potionCount);

        PlayerPrefs.Save();
    }
}
