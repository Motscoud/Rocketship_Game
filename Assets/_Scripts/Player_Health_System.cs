using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health_System : MonoBehaviour
{
    public int startingHealth = 4;

    public int playerTotalLife = 2;

    public int currentHealth;

    public bool IsInvisible = false;

    public Slider HpSlider;

    public Text currentLifeText;

    public Text GameOver;

    public GameObject RestartButton;

	// Use this for initialization
	void Start () {
	    currentHealth = startingHealth;
	    GameOver.text = " ";
	    currentLifeText.text = playerTotalLife.ToString();
	}

	
	// Update is called once per frame
    public void TakeHit (int amount)
    {
        currentHealth -= amount;
        HpSlider.value = currentHealth;
        IsInvisible = true;
        if (currentHealth <= 0)
        {
            if (playerTotalLife >= 1)
            {
                playerTotalLife -= 1;
                currentLifeText.text = playerTotalLife.ToString();
                currentHealth = startingHealth;
                HpSlider.value = currentHealth;
            }

            if (playerTotalLife <= 0)
            {
                Destroy(gameObject);
                GameOver.text = "Game Over";
                RestartButton.SetActive(true);
            }
        }
        Invoke("ResetInvisibility",1);
    }

    public void ResetInvisibility()
    {
    IsInvisible = false;
    }

}


