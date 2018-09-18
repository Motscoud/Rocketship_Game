using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit3D : MonoBehaviour
{
    public int AttackDamage = 1;

    GameObject Boss;

    EnemyDamageSystem3D bosshealth;

    // Use this for initialization
    void Start()
    {
        Boss = GameObject.FindGameObjectWithTag("Enemy");
        bosshealth = Boss.GetComponent<EnemyDamageSystem3D>();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Enemy")
        {
            bosshealth.TakeHit(AttackDamage);
            Destroy(gameObject);
        }

    }

}
