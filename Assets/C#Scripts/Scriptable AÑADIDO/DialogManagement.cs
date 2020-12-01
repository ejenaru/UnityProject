using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManagement : MonoBehaviour
{

    public DialogScriptable dialog;
    public GameObject prefabDialog;

    Text characterDialog;

    public int dialogIndex = 0;

    private void OnEnable()
    {
        Image characterFace = GameObject.FindGameObjectWithTag("Face").GetComponent<Image>();
        characterFace.sprite = dialog.characterFace;
        Text characterName = GameObject.FindGameObjectWithTag("Name").GetComponent<Text>();
        characterName.text = dialog.characterName;
        characterDialog = GameObject.FindGameObjectWithTag("DialogText").GetComponent<Text>();
        characterDialog.text = dialog.dialogText[dialogIndex];
    }

    public void NextLine()
    {
        dialogIndex++;
        if(dialogIndex < dialog.dialogText.Length)
        {
            characterDialog.text = dialog.dialogText[dialogIndex];
        }
        /*else
        {
            prefabDialog.SetActive(false);
        }*/
    }

}
