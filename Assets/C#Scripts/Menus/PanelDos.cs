using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelDos : MonoBehaviour
{

    public GameObject dialogPrefab;
    public InteractionScriptable interactionScriptable;
    public GameObject panelStory;

    bool FinDialogo = false; //Booleano que controla que no se meta en el update antes de que se desactive el dialogo
    bool controladorCorrutina = false; //Controlador para que no se meta más de una vez en la corrutina
    bool nextScene = false; //Controlador para determinar que ya ha terminado la escena


    private void Start()
    {
        StartCoroutine(LoadDialog());
    }
    private void Update()
    {
        if(FinDialogo && !dialogPrefab.activeInHierarchy)
        {
            if (!controladorCorrutina)
            {
                StartCoroutine(FadePanelOut(panelStory.GetComponent<Image>()));
            }
            
            if (nextScene)
            {
                GameManager.manager.SetGameDialog();
                SceneManager.LoadScene(1);
            }

        }
    }


    IEnumerator LoadDialog()
    {
        yield return new WaitForSeconds(3);
        dialogPrefab.SetActive(true);
        PrefabDialog.prefabDialogScript.takeScriptable(this.interactionScriptable);
        FinDialogo = true;
    }

    IEnumerator FadePanelOut(Image panelFade)
    {
        controladorCorrutina = true;
        Color textoColorPanel = panelFade.color;

        while (textoColorPanel.a < 1)
        {
            textoColorPanel.a += 0.1f;
            panelFade.color = textoColorPanel;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(3);
        controladorCorrutina = false;
        nextScene = true;
    }

}
