using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool EnemySpawned;
    public GameObject[] Enemies;

    public int CurrentEnemy;

    void Start()
    {
        EnemySpawned = false;
    }

	
	// Update is called once per frame
	void Update ()
	{
	    if (!EnemySpawned) StartCoroutine(Cycle());
	}

    IEnumerator Cycle()
    {
        EnemySpawned = true;
        Enemies[CurrentEnemy].SetActive(true);
        yield return new WaitForSeconds(5);
        CurrentEnemy++;
        EnemySpawned = false;
    }
}
