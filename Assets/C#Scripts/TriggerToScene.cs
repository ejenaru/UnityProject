using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToScene : MonoBehaviour
{
    public enum sceneType { dungeon, room }

    public int levelToLoad;

    public sceneType scene;

    private void OnTriggerStay2D(Collider2D other)
    {
      /* if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("ToDungeon"))
        {
            //fade to black
            MenuManager.menuManager.LoadLevel(levelToLoad);
        }

        else if (other.gameObject.CompareTag("Player")&& this.gameObject.CompareTag("ToRoom"))
        {
            print("inside ToRoom");
            if (Input.GetButtonDown("Action"))
            {
                print("Action");
                MenuManager.menuManager.LoadLevel(levelToLoad);
            }
                
        }*/


        if (other.gameObject.CompareTag("Player")) {
            /*switch (scene) {
                case sceneType.dungeon: break;

                case sceneType.room: break;
                
                default: break;
            }*/

            if (scene==sceneType.dungeon)
            {
                MenuManager.menuManager.LoadLevel(levelToLoad);
            }
            else
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
}
