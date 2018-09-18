using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Damage : MonoBehaviour {

    public int startingHealth;

    public int currentHealth;

    public GameObject Boss_Music;

    public GameObject Game_Music;

    public GameObject ReInstate_GameControl;

    public Slider HpSlider;

    void Start()
    {
        currentHealth = startingHealth;
        HpSlider.value = currentHealth;
        BossAudioSwap();
    }


    // Update is called once per frame
    public void TakeHit(int amount)
    {
        currentHealth -= amount;
        HpSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            ReInstate_GameControl.SetActive(true);
            GameAudioReturn();
            Destroy(gameObject);

        }
    }

    public void BossAudioSwap()
    {
        AudioSource gamemusicstop = Game_Music.GetComponent<AudioSource>();
        gamemusicstop.Stop();
        AudioSource bossmusicstart = Boss_Music.GetComponent<AudioSource>();
        bossmusicstart.Play();
    }

    public void GameAudioReturn()
    {
        AudioSource bossmusicstop = Boss_Music.GetComponent<AudioSource>();
        bossmusicstop.Stop();
        AudioSource gamemusicstart = Game_Music.GetComponent<AudioSource>();
        gamemusicstart.Play();
    }
}
