using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSystem3D : MonoBehaviour {


    public int startingHealth;

    public int currentHealth;



    void Start()
    {
        currentHealth = startingHealth;
    }


    // Update is called once per frame
    public void TakeHit(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);

        }
    }

}
