using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
    public static GameManager manager; //static para poder acceder a ella sin necesidad de crear un objeto.
    private int currentScene;
    // Start is called before the first frame update
    void Awake()
    {
        manager = this;
        currentScene = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region SceneManagement
    public void LoadLevel(int sceneToLoad) //Función a la que debemos INDICAR mediante un INT el nº de escena que queremos cargar

    {
        currentScene = SceneManager.GetActiveScene().buildIndex; //devuelve en nº de escena y lo guarda 

        SceneManager.LoadScene(sceneToLoad);

    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadLastCheckPoint()
    {
        //No sé como voy a hacer esto todavía.
    }
    public void Quit()
    {
        Application.Quit();
    }
    #endregion
}
