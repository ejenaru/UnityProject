using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    public void RestartButton()
    {
        GameManager.manager.RestartFromSavePoint();
    }
    public void QuitButton()
    {
        GameManager.manager.Quit();
    }
    public void ResumeGame()
    {
        GameManager.manager.SetGamePause();
    }
}
