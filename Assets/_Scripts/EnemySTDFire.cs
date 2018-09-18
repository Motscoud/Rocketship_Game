using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySTDFire : MonoBehaviour {
	public GameObject Shot;
	public Transform ShotSpawn;
	public float FireRate;
	private float nextFire;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFire)
		{
			nextFire = Time.time + FireRate;
			Instantiate(Shot, ShotSpawn);
		}
	}
}
