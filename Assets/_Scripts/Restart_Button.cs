using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart_Button : MonoBehaviour
{
    public Button RestartingButton;
	// Use this for initialization
	void Start ()
	{
	    Button btn = RestartingButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void TaskOnClick () {
		SceneManager.LoadScene("2D_Game");
	}
}
