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





}
