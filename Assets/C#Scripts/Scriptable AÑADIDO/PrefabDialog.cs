using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PrefabDialog : MonoBehaviour
{

    public static PrefabDialog prefabDialogScript;

    public Image characterFace;
    public Text characterName;
    public Text characterDialog;

    public List<string> textoScriptable;

    public int indexDialog = 0;

    bool nextLineOk = false;

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
            if(indexDialog < textoScriptable.Count)
            {
                characterDialog.text = textoScriptable[indexDialog];
            }
            else
            {
                GameManager.manager.SetGameDialog();
                this.gameObject.SetActive(false);
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
}
