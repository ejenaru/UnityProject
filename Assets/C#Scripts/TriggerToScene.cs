using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToScene : MonoBehaviour
{
    public enum sceneType { instant, requireButton}
    public sceneType scene;
    public int levelToLoad;
    public Vector3 playerLoad;
    public Vector3 cameraLoad;



    private void OnTriggerStay2D(Collider2D other)
    //private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            switch (scene) 
            {
                case sceneType.instant:
                    GameManager.manager.sceneStartPosition = playerLoad;
                    GameManager.manager.cameraPosition = cameraLoad;
                    GameManager.manager.LoadLevel(levelToLoad);
                    break;

                case sceneType.requireButton:
                    if (Input.GetButtonDown("Action"))
                    {
                        print("Action");
                        GameManager.manager.sceneStartPosition = playerLoad;
                        GameManager.manager.cameraPosition = cameraLoad;
                        GameManager.manager.LoadLevel(levelToLoad);
                    }
                    break;
                
                default: break;
            }

        }
    }
}
