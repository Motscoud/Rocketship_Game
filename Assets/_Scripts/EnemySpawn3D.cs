using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn3D : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    [SerializeField]float spawnTimer = 5f;
	// Use this for initialization
	void Start ()
	{
	    StartSpawning();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnEnemy", spawnTimer, spawnTimer);
    }

    float Offset()
    {
        return Random.Range(1, 20);
    }
}
