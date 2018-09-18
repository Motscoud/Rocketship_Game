using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hit : MonoBehaviour
{
    public int Attack_Damage;

    GameObject Spaceship;

    Player_Health_System playerHealth;

    void Start()
    {
        Spaceship = GameObject.FindGameObjectWithTag("Player");
        playerHealth = Spaceship.GetComponent<Player_Health_System>();
    }
	// Use this for initialization
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!playerHealth.IsInvisible)
        {
            if (other.tag == "Player")
            {
                playerHealth.TakeHit(Attack_Damage);
            }
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (!playerHealth.IsInvisible)
        {
            if (other.tag == "Player")
            {
                playerHealth.TakeHit(Attack_Damage);
            }
        }

    }

}
