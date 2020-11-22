using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    public static LootManager loot;
    public int keyNumber;
    void Awake()
    {
        loot = this;
        keyNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
