using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerInteraction : MonoBehaviour
{
    public GameObject dialogPrefab;
    public InteractionScriptable interactionScriptable;
    public GameObject clickToInteract;

    bool playerTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerTrigger = true;
            clickToInteract.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerTrigger = false;
            clickToInteract.SetActive(false);
        }
    }

    private void Update()
    {
        if(playerTrigger && Input.GetKeyDown(KeyCode.E) && !dialogPrefab.activeInHierarchy)
        {
            AudioController.audioManager.OpenDialogue();
            GameManager.manager.SetGameDialog();
            clickToInteract.SetActive(false);
            dialogPrefab.SetActive(true);
            PrefabDialog.prefabDialogScript.takeScriptable(this.interactionScriptable);
           
        }
    }

}
