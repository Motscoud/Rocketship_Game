using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    public float minScale = .8f;
    public float maxScale = 1.2f;
    Transform myTransform;
    Vector3 randomRotation;

    private void Awake()
    {
        myTransform = transform;
    }
    // Use this for initialization
    void Start () {
        //RNG Size
        Vector3 scale = Vector3.one;
        scale.x = Random.Range(minScale, maxScale);
        scale.y = Random.Range(minScale, maxScale);
        scale.z = Random.Range(minScale, maxScale);

        myTransform.localScale = scale;
        //RNG Rotation
        randomRotation.x = Random.Range(minScale, maxScale);
        randomRotation.y = Random.Range(minScale, maxScale);
        randomRotation.z = Random.Range(minScale, maxScale);
    }
	
	// Update is called once per frame
	void Update () {
        myTransform.Rotate(randomRotation * Time.deltaTime);
	}
}
