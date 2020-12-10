using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PrefabDialog : MonoBehaviour
{
    // ------Final------
    bool controladorCorrutina = false;
    bool nextScene = false;
    public GameObject panelFade;



    public static PrefabDialog prefabDialogScript;

    public Image characterFace;
    public Text characterName;
    public Text characterDialog;

    public List<string> textoScriptable;

    public int indexDialog = 0;

    bool nextLineOk = false;
    public bool interactionEnd = false;

    private void Awake()
    {
        prefabDialogScript = this;
    }
    private void OnDisable()
    {
        indexDialog = 0;
        textoScriptable.Clear();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && nextLineOk)
        {
            indexDialog++;
            if (indexDialog < textoScriptable.Count)
            {
                characterDialog.text = textoScriptable[indexDialog];
            }
            else
            {
                GameManager.manager.SetGameDialog();
                //if(!GameManager.manager.player.GetComponent<PlayerControllerTOP>().playerInBedFinale)
                this.gameObject.SetActive(false);
                if (GameManager.manager.player != null && SceneManager.GetActiveScene().buildIndex == 1)
                {
                    
                    if (GameManager.manager.player.GetComponent<PlayerControllerTOP>().playerInBedFinale)
                    {

                        GameManager.manager.LoadLevel(4);


                        //controladorCorrutina = false;
                        //if (!controladorCorrutina)
                        //{
                        //    Image fadeImage = panelFade.GetComponent<Image>();
                        //    StartCoroutine(FadePanelOut(fadeImage));
                        //}

                        //if (nextScene)
                        //{
                        //    controladorCorrutina = true;
                        //    nextScene = false;
                            
                        //    GameManager.manager.LoadLevel(4);
                        //}
                        
                    }
                }

            }
        }
    }

    public void takeScriptable(InteractionScriptable scriptable)
    {
        characterFace.sprite = scriptable.characterFace;
        characterName.text = scriptable.characterName;
        characterDialog.text = scriptable.interaction[indexDialog];

        for (int i = 0; i < scriptable.interaction.Length; i++)
        {
            textoScriptable.Add(scriptable.interaction[i]);
        }

        nextLineOk = true;
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
        Debug.Log("Final corrutina");

        nextScene = true;
        //Debug.Log("NEXT SCENE (fade): " + nextScene);
        controladorCorrutina = false;
;
        yield return new WaitForSeconds(3);
        GameManager.manager.LoadLevel(4);

    }
}
