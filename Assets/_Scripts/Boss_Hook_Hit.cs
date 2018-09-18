using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Hook_Hit : MonoBehaviour
{
    public int AttackDamage = 1;

    GameObject Boss;

    Boss_Damage bosshealth;

    // Use this for initialization
    void Start()
    {
        Boss = GameObject.FindGameObjectWithTag("Boss");
        bosshealth = Boss.GetComponent<Boss_Damage>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Boss")
        {
            bosshealth.TakeHit(AttackDamage);
            Destroy(gameObject);
        }

    }
}