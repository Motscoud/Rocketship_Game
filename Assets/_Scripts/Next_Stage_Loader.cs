using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Stage_Loader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneManager.LoadScene("Cutscene_Test");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
