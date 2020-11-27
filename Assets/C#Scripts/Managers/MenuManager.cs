using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioMixer audioMixer;
    public AudioClip volumenPrueba;
    public GameObject sliderVolume;


    private void Start()
    {
        //LoadPlayerPrefs();
        audioSource = GetComponent<AudioSource>();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
