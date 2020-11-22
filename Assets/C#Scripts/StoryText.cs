using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryText : MonoBehaviour
{
    public string[] frasesHistoria;
    public Text textoHistoria;
    public Text clickToNextLine; //Texto "Pulse click izquierdo para pasar a la siguiente línea de historia"

    public GameObject panelStory; //Panel en el que se cuenta la historia
    public GameObject fadeToMenu;

    AudioSource audioSource;
    public AudioClip musicIntro;

    int numeroFrases = 0;
    int finDeHistoria = 0;


    bool controlador = true;
    bool controladorVolumen;
    bool controladorFadePanel;
    bool controladorEnd;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicIntro;
        audioSource.Play();
        clickToNextLine.gameObject.SetActive(false);
        StartCoroutine(FadeIn(textoHistoria));
    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && controlador)
        {
            if (numeroFrases < frasesHistoria.Length)
            {
                StartCoroutine(FadeInOut(textoHistoria));
            }

        }
        if (finDeHistoria == 1 && !controladorVolumen)
        {

            StartCoroutine(FadeMusic(audioSource));

        }
        if (controladorVolumen && !controladorFadePanel)
        {
            StartCoroutine(FadeOut(fadeToMenu.GetComponent<Image>()));

        }
        if (controladorEnd)
        {
            audioSource.Stop();
            panelStory.SetActive(false);
        }

    }


    IEnumerator FadeIn(Text textoIn)
    {
        textoHistoria.text = frasesHistoria[numeroFrases];
        Color textoColorIn = textoIn.color;

        while (textoColorIn.a < 1)
        {
            textoColorIn.a += 0.1f;
            textoIn.color = textoColorIn;
            yield return new WaitForSeconds(0.1f);
        }

        clickToNextLine.gameObject.SetActive(true);

    }
    IEnumerator FadeOut(Image panelFade)
    {
        controladorFadePanel = true;
        Color textoColorPanel = panelFade.color;

        while (textoColorPanel.a < 1)
        {
            textoColorPanel.a += 0.1f;
            panelFade.color = textoColorPanel;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2);
        controladorEnd = true;
    }

    IEnumerator FadeInOut(Text textoInOut)
    {
        clickToNextLine.gameObject.SetActive(false);
        controlador = false;

        Color textoColorInOut = textoInOut.color;

        while (textoColorInOut.a > 0)
        {
            textoColorInOut.a -= 0.1f;
            textoInOut.color = textoColorInOut;
            yield return new WaitForSeconds(0.1f);
        }

        numeroFrases++;

        if (numeroFrases < frasesHistoria.Length)
        {
            yield return new WaitForSeconds(1);

            textoHistoria.text = frasesHistoria[numeroFrases];
            while (textoColorInOut.a < 1)
            {
                textoColorInOut.a += 0.1f;
                textoInOut.color = textoColorInOut;
                yield return new WaitForSeconds(0.1f);
            }

            clickToNextLine.gameObject.SetActive(true);
            controlador = true;
        }
        else
        {
            finDeHistoria++;
        }
    }
    IEnumerator FadeMusic(AudioSource audio)
    {
        while (audio.volume != 0)
        {
            audio.volume -= 0.005f;
            yield return new WaitForSeconds(0.1f);
        }
        controladorVolumen = true;
    }
}
