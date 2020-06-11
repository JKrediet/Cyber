using UnityEngine;
using UnityEngine.UI;

public class RangedAttack : MonoBehaviour
{
    public Rigidbody arrow;
    public Slider aimPowerSlider;
    public Transform arrowForward, test;

    // arrow variables
    private float arrowSpeed, arrowDamage, baseMaxDamage;
    public float aimPower, maxArrowPower, maxArrowDamage, arrowDamageIncreasement;

    // crit
    private int isCrit;
    private float baseCritChance, baseCritDamage;
    public float critDamage, critDamageIncreasement, critChance, critChanceIncreasement;

    private void Awake()
    {
        baseCritDamage = critDamage;
        baseCritChance = critChance;
        baseMaxDamage = maxArrowDamage;
    }
    private void Update()
    {
        Attack();
    }
    public void Attack()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            GetComponent<AudioMC>().Bow_aiming();
        }

        if (Input.GetButton("Fire2"))
        {
            GetComponent<MeleeAttack>().cooldown = true;
            aimPowerSlider.gameObject.SetActive(true);
            if (arrowSpeed <= maxArrowPower)
            {
                arrowSpeed += aimPower * Time.deltaTime;
                aimPowerSlider.value = arrowSpeed;
            }
            else
            {
                arrowSpeed = maxArrowPower;
            }
            if (arrowDamage <= maxArrowDamage)
            {
                arrowDamage += maxArrowDamage * Time.deltaTime;
            }
        }
        if (Input.GetButtonUp("Fire2"))
        {
            GetComponent<AudioMC>().Bow_release();
            GetComponent<AudioMC>().Zoof();
            GetComponent<MeleeAttack>().cooldown = false;
            aimPowerSlider.gameObject.SetActive(false);

            // zorgen dat dmg niet meer dan max dmg is
            if (arrowDamage > maxArrowDamage)
            {
                arrowDamage = maxArrowDamage;
            }

            //crit kans berekenen
            isCrit = Random.Range(0, 101);
            if (critChance >= isCrit)
            {
                arrowDamage *= critDamage;
            }
            Rigidbody clone;
            clone = Instantiate(arrow, test.position + test.forward, arrowForward.rotation);
            clone.gameObject.GetComponent<RangedBehavior>().givenDamage = arrowDamage;
            clone.velocity = transform.TransformDirection(0, arrowForward.forward.y * arrowSpeed, 1 * arrowSpeed);
            arrowSpeed = 0;
            arrowDamage = 0;
            aimPowerSlider.value = arrowSpeed;
        }
    }
    public void Reset()
    {
        RangedDamageSkillnote(default);
        RangedCritChanceSkillnote(default);
        RangedCritDamageSkillnote(default);
    }
    #region skillpoints
    // skillpoint reward > ranged damage
    public void RangedDamageSkillnote(float skillAnount)
    {
        float newDamage = baseMaxDamage;
        newDamage += arrowDamageIncreasement * skillAnount;

        maxArrowDamage = newDamage;

        // naar stats in skilltree sturen
        StuurRDamage();
    }
    // skillpoint reward > crit chance
    public void RangedCritChanceSkillnote(float skillAmount)
    {
        float newCritChance = baseCritChance;
        newCritChance += critChanceIncreasement * skillAmount;

        critChance = newCritChance;

        // naar stats in skilltree sturen
        StuurRCChance();
    }
    // skillpoint reward > crit damage
    public void RangedCritDamageSkillnote(float skillAmount)
    {
        float newCritDamage = baseCritDamage;
        newCritDamage += critDamageIncreasement * skillAmount;

        critDamage = newCritDamage;

        // naar stats in skilltree sturen
        StuurRCDamage();
    }
    public void StuurRDamage()
    {
        if (FindObjectOfType<UI_Skill_Info>() != null)
        {
            FindObjectOfType<UI_Skill_Info>().RDamage(maxArrowDamage);
        }
        else
        {
            Invoke("StuurRDamage", 0.01f);
        }
    }
    public void StuurRCChance()
    {
        if (FindObjectOfType<UI_Skill_Info>() != null)
        {
            FindObjectOfType<UI_Skill_Info>().RCChance(critChance);
        }
        else
        {
            Invoke("StuurRCChance", 0.01f);
        }
    }
    public void StuurRCDamage()
    {
        if (FindObjectOfType<UI_Skill_Info>() != null)
        {
            FindObjectOfType<UI_Skill_Info>().RCDamage(critDamage);
        }
        else
        {
            Invoke("StuurRCDamage", 0.01f);
        }
    }
    #endregion
}
