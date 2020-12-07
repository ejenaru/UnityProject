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
    public AudioSource bossHurt;
    public AudioSource bossDeaht;
    // Start is called before the first frame update
    void Awake()
    {
        audioManager = this;

        UIAudios = UIAudio.GetComponents<AudioSource>();
        click = UIAudios[0];

        //UIMusics = ... 

    }


    public void ClickSFX()
    {
        if (!click.isPlaying)
            click.Play();
    }
    public void Blacksmith()
    {
        if (!blackSmith.isPlaying)
            blackSmith.Play();
    }

    public void KnockDoor()
    {
        if (!door.isPlaying)
            door.Play();
    }

    public void DialogueSens()
    {
        if (!dialogueSens.isPlaying)
            dialogueSens.Play();
    }

    public void Birds()
    {
        if (!birds.isPlaying)
            birds.Play();
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

    public void Key()
    {
        if (!key.isPlaying)
            key.Play();
    }

    public void ShootPlayer()
    {
        if (!shootPlayer.isPlaying)
            shootPlayer.Play();
    }

    public void BossHurt()
    {
        if (!bossHurt.isPlaying)
            bossHurt.Play();
    }

    public void BossDeath()
    {
        if (!bossDeaht.isPlaying)
            bossDeaht.Play();
    }
}
