using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsReplay : MonoBehaviour
{


    public GameObject replayButton;
    // Start is called before the first frame update


    public void ReplayButton()
    {
        replayButton.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
