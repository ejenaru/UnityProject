using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip volumenPrueba;
    public GameObject sliderVolume;


    private void Start()
    {
        LoadPlayerPrefs();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
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
        audioSource.volume = volume;
        SavePlayerPrefs(volume);
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
