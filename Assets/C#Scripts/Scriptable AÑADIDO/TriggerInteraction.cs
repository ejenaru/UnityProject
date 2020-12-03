using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerInteraction : MonoBehaviour
{
    public GameObject dialogPrefab;
    public InteractionScriptable interaction;

    bool playerTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerTrigger = false;
        }
    }
    private void Update()
    {
        if(playerTrigger && Input.GetKeyDown(KeyCode.E))
        {
            dialogPrefab.SetActive(true);
            GameObject.FindGameObjectWithTag("Text").GetComponent<Text>().text = interaction.interaction;
        }
    }

}
