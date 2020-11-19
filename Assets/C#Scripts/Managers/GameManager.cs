﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
    //------VARIABLES QUE VAMOS A USAR MUCHAS VECES LAS GUARDAMOS AQUI
    public static GameManager manager; //static para poder acceder a ella sin necesidad de crear un objeto.
    public GameObject player;
    public LootManager loot;
    public Pooler pool;
    private int currentScene;
    //Se puede guardar en un array los nombres de las escenas.

    private void Awake()
    {

        manager = this; //singletone
        DontDestroyOnLoad(this.gameObject);
        //Voy a guardar aqui el player para usarlo en varias ocasiones, así no tengo que hacer el findgameobject más veces.
        player = GameObject.FindWithTag("Player");
        currentScene = 0;
    }
    void Start() //esto tiene que ir en start porque si no no encuentra el loot, que se asigna en awake no se si estará bien o me dará mas fallos
    {
        loot = LootManager.loot;
        pool = Pooler.pooler;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region SceneManagement
    public void LoadLevel(int sceneToLoad) //Función a la que debemos INDICAR mediante un INT el nº de escena que queremos cargar

    {

        //aqui hacemos el fade para la pantalla de carga.

        currentScene = SceneManager.GetActiveScene().buildIndex; //devuelve en nº de escena y lo guarda 
        //hacer aqui una tansicion a negro y despues cargar la escena

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
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
#endregion
}
