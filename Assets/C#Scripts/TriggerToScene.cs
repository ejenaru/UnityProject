using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToScene : MonoBehaviour
{
    public int levelToLoad;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("ToDungeon"))
        {
            //fade to black
            MenuManager.menuManager.LoadLevel(levelToLoad);
        }
        if (other.gameObject.CompareTag("Player")&& this.gameObject.CompareTag("ToRoom"))
        {
            print("inside ToRoom");
            if (Input.GetButtonDown("Action"))
            {
                print("Action");
                MenuManager.menuManager.LoadLevel(levelToLoad);
            }
                
        }
    }
}
