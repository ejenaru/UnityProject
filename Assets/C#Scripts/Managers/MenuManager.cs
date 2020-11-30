using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    public static MenuManager menuManager;
    AudioSource audioSource;
    public AudioMixer audioMixer;
    public AudioClip volumenPrueba;
    public GameObject sliderVolume;


    private void Start()
    {
        menuManager = this;
        //LoadPlayerPrefs();
        audioSource = GetComponent<AudioSource>();
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PlayVolume()
    {
        sliderVolume.SetActive(true);
        audioSource.clip = volumenPrueba;
        audioSource.Play();
    }
    public void ChangeVolumen(float volume)
    {
        audioMixer.SetFloat("Master", volume);
       // SavePlayerPrefs(volume);
    }

    public void SavePlayerPrefs(float volume)
    {
        PlayerPrefs.SetFloat("VolumenGeneral", volume);
        PlayerPrefs.Save();
    }
    public void LoadPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("VolumenGeneral"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("VolumenGeneral");
        }
    }
}
