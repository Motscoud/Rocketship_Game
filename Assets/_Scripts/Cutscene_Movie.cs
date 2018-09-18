using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Cutscene_Movie : MonoBehaviour {

    public MovieTexture Cutscene;
    public string NextSceneName;

    public void Start()
    {
        StartCoroutine(WaitAndLoadScene(Cutscene.duration, NextSceneName));
        Cutscene.Play();
    }

    public void Update()
    {
        HasPlayerSkipped();
    }

    public void OnGUI()
    {
        Vector3 scale;

        float ResolutionX = 1920;
        float ResolutionY = 1080;

        scale.x = (float)Screen.width / ResolutionX;
        scale.y = (float)Screen.height / ResolutionY;
        scale.z = 1;

        Matrix4x4 svMat = GUI.matrix;
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, scale);

        GUI.DrawTexture(new Rect(0, 0, ResolutionX, ResolutionY), Cutscene);
    }

    void HasPlayerSkipped()
    {
        bool IsSkipButtonDown = Input.GetButtonDown("Cancel");
        if (IsSkipButtonDown)
        {
            SceneManager.LoadScene(NextSceneName);
        }
    }

    private IEnumerator WaitAndLoadScene(float value, string scene)
    {
        yield return new WaitForSeconds(value);
        SceneManager.LoadScene(scene);
    }
}
