using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController audioManager;

    public GameObject UIAudio;
    public AudioSource[] UIAudios;
    //public AudioSource[] Music;

    //------------- audio de interfaz
    public AudioSource click;
    public AudioSource deathSpikes;
    public AudioSource gravityChange;
    public AudioSource coin;
    public AudioSource key;
    public AudioSource blackSmith;
    public AudioSource door;
    public AudioSource dialogueSens;
    public AudioSource birds;
    public AudioSource openDialogue;
    public AudioSource shootPlayer;
    public AudioSource enemyHurt;
    public AudioSource bossDeaht;
    public AudioSource playerHurt;
    // Start is called before the first frame update
    void Awake()
    {
        audioManager = this;

        UIAudios = UIAudio.GetComponents<AudioSource>();
        click = UIAudios[0];
        openDialogue = UIAudios[1];
        gravityChange = UIAudios[2];
        dialogueSens = UIAudios[3];
        shootPlayer = UIAudios[4];
        coin = UIAudios[5];
        deathSpikes = UIAudios[6];
        enemyHurt = UIAudios[7];
        bossDeaht = UIAudios[8];
        playerHurt = UIAudios[9];
        //UIMusics = ... 

    }


    public void ClickSFX()
    {
        if (!click.isPlaying)
            click.Play();
    }

    public void OpenDialogue()
    {
        if (!openDialogue.isPlaying)
            openDialogue.Play();
    }
    public void DeathSpikes()
    {
        if (!deathSpikes.isPlaying)
            deathSpikes.Play();
    }

    public void GravityChange()
    {
        if (!gravityChange.isPlaying)
            gravityChange.Play();
    }

    public void Coin()
    {
        if (!coin.isPlaying)
            coin.Play();
    }

    public void ShootPlayer()
    {
        if (!shootPlayer.isPlaying)
            shootPlayer.Play();
    }

    public void EnemyHurt()
    {
        if (!enemyHurt.isPlaying)
            enemyHurt.Play();
    }

    public void BossDeath()
    {
        if (!bossDeaht.isPlaying)
            bossDeaht.Play();
    }

    public void PlayerHurt()
    {
        if (!playerHurt.isPlaying)
            playerHurt.Play();
    }
}
