using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;

    // damage
    public float maxMeleeDamage, meleeDamageIncreasement;
    private float baseDamage, meleeDamage;

    // crit
    private int isCrit;
    private float baseCritChance, baseCritDamage;
    public float critDamage, critDamageIncreasement, critChance, critChanceIncreasement;

    private void Awake()
    {
        baseDamage = maxMeleeDamage;
        baseCritChance = critChance;
        baseCritDamage = critDamage;
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            meleeDamage = maxMeleeDamage;
            //crit kans berekenen
            isCrit = Random.Range(0, 101);
            if (critChance >= isCrit)
            {
                meleeDamage *= critDamage;
            }
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider enemy in hitEnemies)
            {
                enemy.GetComponent<HealthTotal>().Health(meleeDamage);
            }
        }
    }
    public void Reset()
    {
        MeleeDamageSkillnote(default);
        MeleeCritChanceSkillnote(default);
        MeleeCritDamageSkillnote(default);
    }
    #region skillpoints
    // skillpoint reward > melee damage
    public void MeleeDamageSkillnote(float skillAmount)
    {
        float newDamage = baseDamage;
        newDamage += meleeDamageIncreasement * skillAmount;

        maxMeleeDamage = newDamage;

        // naar stats in skilltree sturen
        StuurMDamage();
    }
    // skillpoint reward > crit chance
    public void MeleeCritChanceSkillnote(float skillAmount)
    {
        float newCritChance = baseCritChance;
        newCritChance += critChanceIncreasement * skillAmount;

        critChance = newCritChance;

        // naar stats in skilltree sturen
        StuurMCChance();
    }
    // skillpoint reward > crit damage
    public void MeleeCritDamageSkillnote(float skillAmount)
    {
        float newCritDamage = baseCritDamage;
        newCritDamage += critDamageIncreasement * skillAmount;

        critDamage = newCritDamage;

        // naar stats in skilltree sturen
        StuurMCDamage();
    }
    #endregion

    public void StuurMDamage()
    {
        if (FindObjectOfType<UI_Skill_Info>() != null)
        {
            FindObjectOfType<UI_Skill_Info>().MDamage(maxMeleeDamage);
        }
        else
        {
            Invoke("StuurMDamage", 1);
        }
    }
    public void StuurMCChance()
    {
        if (FindObjectOfType<UI_Skill_Info>() != null)
        {
            FindObjectOfType<UI_Skill_Info>().MCChance(critChance);
        }
        else
        {
            Invoke("StuurMCChance", 1);
        }
    }
    public void StuurMCDamage()
    {
        if (FindObjectOfType<UI_Skill_Info>() != null)
        {
            FindObjectOfType<UI_Skill_Info>().MCDamage(critDamage);
        }
        else
        {
            Invoke("StuurMCDamage", 1);
        }
    }

    //debug
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
