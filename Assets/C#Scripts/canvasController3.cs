using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasController3 : MonoBehaviour
{
    public Slider canvasHealth;
    private PlayerHealth playerHealth;
    public Text keyText;

    void Start()
    {
        playerHealth = GameManager.manager.player.GetComponent<PlayerHealth>();
        
        canvasHealth.maxValue = playerHealth.maxValue;
        canvasHealth.value = playerHealth.GetHealthValue();
    }

    // Update is called once per frame
    void Update()
    {
        keyText.text = LootManager.loot.keyNumber.ToString();
        canvasHealth.value = playerHealth.GetHealthValue();
    }
}
