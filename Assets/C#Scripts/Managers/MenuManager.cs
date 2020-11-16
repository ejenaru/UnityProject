using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip volumenPrueba;
    public Slider sliderVolume;


    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ChangeVolume()
    {
        audioSource.clip = volumenPrueba;
        audioSource.Play();
        audioSource.volume = sliderVolume.value;
    }
}
