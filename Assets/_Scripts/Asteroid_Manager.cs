using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Manager : MonoBehaviour {
    [SerializeField]Asteroid asteroid;
    [SerializeField] int numberOfAsteroidsOnAxis = 10;
    [SerializeField] int GridSpacing = 100;
	// Use this for initialization
	void Start () {
        PlaceAsteroids();
	}
	
    void PlaceAsteroids()
    {
        for(int x = 0; x < numberOfAsteroidsOnAxis; x++)
        {
            for(int y = 0; y < numberOfAsteroidsOnAxis; y++)
            {
                for(int z = 0; z < numberOfAsteroidsOnAxis; z++)
                {
                    InstantiateAsteroid(x, y, z);
                }
            }
        }
    }

    void InstantiateAsteroid(int x, int y, int z)
    {
        Instantiate(asteroid,
            new Vector3(transform.position.x + (x * GridSpacing) + AndroidOffset(),
            transform.position.y + (y * GridSpacing)+ AndroidOffset(),
            transform.position.z + (z*GridSpacing) + AndroidOffset()), 
            Quaternion.identity, 
            transform);
    }

    float AndroidOffset()
    {
        return Random.Range(-GridSpacing / 2f, GridSpacing / 2f);
    }
  
}
