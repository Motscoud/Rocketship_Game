using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene_Level_Loader : MonoBehaviour
{
    public GameObject Movie;
	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(WaitAndLoadScene(Movie.GetComponent<MovieTexture>().duration, "3D_Game"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator WaitAndLoadScene(float value, string scene)
    {
        yield return new WaitForSeconds(value);
        SceneManager.LoadScene(scene);
    }
}
