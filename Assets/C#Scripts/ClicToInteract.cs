using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicToInteract : MonoBehaviour
{
    public GameObject keyNeeded;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && LootManager.loot.keyNumber < 1)
        {
            keyNeeded.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && LootManager.loot.keyNumber < 1)
        {
            keyNeeded.SetActive(false);
        }
    }
}
