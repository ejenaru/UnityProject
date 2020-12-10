using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManagement : MonoBehaviour
{

    public DialogScriptable dialog;
    public GameObject prefabDialog;

    Text characterDialog;
    Text characterName;
    Image characterFace;

    public int dialogIndex = 0;

    //private void OnEnable()
    private void Start() //Se ha cambiado de Start
    {
        //Image characterFace = GameObject.FindGameObjectWithTag("Face").GetComponent<Image>();
        characterFace = prefabDialog.transform.Find("Inside").Find("HeadImageMark").Find("HeadImage").GetComponent<Image>();
        characterFace.sprite = dialog.characterFace;
        //Text characterName = GameObject.FindGameObjectWithTag("Name").GetComponent<Text>();
        characterName = prefabDialog.transform.Find("Inside").Find("HeadName").GetComponent<Text>();
        characterName.text = dialog.characterName;
        //characterDialog = GameObject.FindGameObjectWithTag("DialogText").GetComponent<Text>();
        characterDialog = prefabDialog.transform.Find("Inside").Find("DialogText").GetComponent<Text>();
        characterDialog.text = dialog.dialogText[dialogIndex];
    }

    private void Update()//ADDED
    {
        NextLine();
        
    }

    /*public void NextLineClick()
    {
        dialogIndex++;
        if(dialogIndex < dialog.dialogText.Length)
        {
            characterDialog.text = dialog.dialogText[dialogIndex];
        }
        AudioController.audioManager.ClickSFX();

        /*else
        {
            prefabDialog.SetActive(false);
        }
    }*/

    void NextLine()//ADDED
    {
        if (prefabDialog.activeInHierarchy && Input.GetKeyDown(KeyCode.E))
        {
            
            dialogIndex++;
           

            if (dialogIndex < dialog.dialogText.Length)
            {
                
                characterDialog.text = dialog.dialogText[dialogIndex];
                

            }

        }
        if(dialogIndex == dialog.dialogText.Length)
        {
            prefabDialog.SetActive(false);
            dialogIndex = 0;
        }
    }

}
