using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerToScene : MonoBehaviour
{
    public enum sceneType { instant, requireButton }
    public sceneType scene;
    public int levelToLoad;
    public Vector3 playerLoad;
    public Vector3 cameraLoad;

    //GameObject añadido para coger el fade
    bool nextScene = false;
    bool controladorCorrutina = false;
    GameObject panelFade;

    public GameObject clicToInteract;



    private void Start()
    {
        panelFade = GameObject.FindGameObjectWithTag("Fade");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        clicToInteract.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D other)
    //private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            
            switch (scene)
            {
                case sceneType.instant:
                    
                    //Añadido el fade
                    if (!controladorCorrutina)
                    {
                        Image fadeImage = panelFade.GetComponent<Image>();
                        StartCoroutine(FadePanelOut(fadeImage));
                    }

                    //if (nextScene)
                    //{
                    //    //controladorCorrutina = false;
                    //    //nextScene = false;
                    //    //GameManager.manager.playerStartPosition = playerLoad;
                    //    //GameManager.manager.cameraPosition = cameraLoad;
                    //    //GameManager.manager.LoadLevel(levelToLoad);
                    //}
                    break;

                case sceneType.requireButton:
                    if (Input.GetButtonDown("Action"))
                    {
                        if (!controladorCorrutina)
                        {
                            Image fadeImage = panelFade.GetComponent<Image>();
                            StartCoroutine(FadePanelOut(fadeImage));
                        }
                    }
                    clicToInteract.SetActive(true);

                    //if (nextScene)
                    //{
                    //    print("Action");
                    //    nextScene = false;
                    //    GameManager.manager.playerStartPosition = playerLoad;
                    //    GameManager.manager.cameraPosition = cameraLoad;
                    //    GameManager.manager.LoadLevel(levelToLoad);
                    //}
                    break;


                default: break;
            }

        }
    }
    IEnumerator FadePanelOut(Image panelFade)
    {
        GameManager.manager.SetGameDialog();
        controladorCorrutina = true;
        Color textoColorPanel = panelFade.color;

        while (textoColorPanel.a < 1)
        {
            textoColorPanel.a += 0.1f;
            panelFade.color = textoColorPanel;
            yield return new WaitForSeconds(0.1f);
        }
        //Debug.Log("Final corrutina");
        
        nextScene = true;
        //Debug.Log("NEXT SCENE (fade): " + nextScene);
        controladorCorrutina = false;
        nextScene = false;
        GameManager.manager.playerStartPosition = playerLoad;
        GameManager.manager.cameraPosition = cameraLoad;
        yield return new WaitForSeconds(3);
        GameManager.manager.SetGameDialog();
        
        GameManager.manager.LoadLevel(levelToLoad);

    }
}
