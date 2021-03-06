﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
    //------VARIABLES QUE VAMOS A USAR MUCHAS VECES LAS GUARDAMOS AQUI
    public GameObject cam;
    public static GameManager manager; //static para poder acceder a ella sin necesidad de crear un objeto.

    //-------PLAYER PREFS------
    public GameObject player;
    //-------GUARDAR AL CAMBIAR DE ROOM----
    private Vector3 initialPosition = new Vector3(-0.5f, 2f, 0);
    public Vector3 playerStartPosition; //La posición que toma el personaje al pasar por el trigger
    public Vector3 cameraPosition;
    public GameObject roomKilled;
    public int currentScene;

    //------ESTADO GAME---------
    private bool gamePause = false;
    private bool dialogState = false;
    public bool bossKilled = false;
    public GameObject pauseCanvas;
    public GameObject gameOverCanvas;
    public GameObject canvas;
    GameObject pauseObjectInScene = null;

    //private gameState;  //0 - menu, 1 - dialog, 2 - battle, 3 - world, 4 - dungeon 

    

    private void Awake()
    {
        //cam = Camera.main.gameObject;
        manager = this; //singletone
        DontDestroyOnLoad(this.gameObject);
        //Voy a guardar aqui el player para usarlo en varias ocasiones, así no tengo que hacer el findgameobject más veces.
        //player = GameObject.FindWithTag("Player");
        SceneManager.sceneLoaded += OnSceneLoaded;
        //pauseCanvas = GameObject.FindWithTag("PanelPausa");


    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 4)
        {

            pauseCanvas = GameObject.Find("Canvas").gameObject.transform.Find("PanelPausa").gameObject;
        }
        
        cam = Camera.main.gameObject;
        player = GameObject.FindWithTag("Player");
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            
            gameOverCanvas = GameObject.Find("Canvas").gameObject.transform.Find("PanelGameOver").gameObject;
        }
                    
        Pooler.pooler.enabled = false;
        Pooler.pooler.enabled = true;
    }

    void Start() //esto tiene que ir en start porque si no no encuentra el loot, que se asigna en awake no se si estará bien o me dará mas fallos
    {
        
        cameraPosition = new Vector3(0, 0, -10);
        playerStartPosition = initialPosition;
        //instanciar al personaje
        //player = Instantiate(PlayerPrefab, gameStartPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

        //if (SceneManager.GetActiveScene().Equals(3))
        //    gameOverCanvas = GameObject.Find("Canvas").gameObject.transform.Find("PanelGameOver").gameObject;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetGamePause();
        }
    }
    //void OnSceneLoaded()
    //{
    //    if (SceneManager.GetActiveScene().Equals(3))
    //        gameOverCanvas = GameObject.Find("Canvas").gameObject.transform.Find("PanelGameOver").gameObject;
    //}


    #region SceneManagement
    public void LoadLevel(int sceneToLoad) //Función a la que debemos INDICAR mediante un INT el nº de escena que queremos cargar

    {

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


    #region Pause

    public void SetGamePause()
    {
        if (pauseCanvas != null)
        {
            dialogState = !dialogState;
            //activar canvas de pausa

            pauseCanvas.SetActive(!pauseCanvas.activeInHierarchy);

        }

    }

    public bool GetGamePause()
    {
        return gamePause;
    }


    #endregion

    #region dialogState
    public void SetGameDialog()
    {
        dialogState = !dialogState;
        //activar canvas de pausa

        
    }

    public bool GetDialogState()
    {
        return dialogState;
    }
    #endregion


    #region KillBoss
    public void SetBossKilled()
    {
        bossKilled = !bossKilled;
        //activar canvas de pausa


    }

    public bool GetBossKilled()
    {
        return bossKilled;
    }
    #endregion

    #region SavePoint
    public void UpdateSavePoint(Vector3 newPosition, GameObject room)
    {
        roomKilled = room;
        playerStartPosition = new Vector3(newPosition.x, newPosition.y, 0);   //ponemos la Z a 0 porque el sistema de particulas está en z=-12
    }


    #endregion



    public void KillPlayer()
    {

        //gameOverCanvas = GameObject.Find("Canvas").gameObject.transform.Find("PanelGameOver").gameObject;
        print("KILL PLAYER");
        player.SetActive(false);
        gameOverCanvas.SetActive(true);
        //activar panel

        //player.transform.position = playerStartPosition;
        //player.SetActive(true);

        //player = Instantiate(PlayerPrefab, playerStartPosition, Quaternion.identity);
        //cam.GetComponent<CameraFollowTOP>().SetPosition(roomKilled);

    }
    public void RestartFromSavePoint()
    {
        player.SetActive(true);
        player.transform.position = playerStartPosition;
        if (!player.GetComponent<PlayerControllerFRONT>().isGravityPositive)
        player.GetComponent<PlayerControllerFRONT>().ChangeGravity();

        //player = Instantiate(PlayerPrefab, playerStartPosition, Quaternion.identity);
        cam.GetComponent<CameraFollowTOP>().SetPosition(roomKilled);
        player.GetComponent<PlayerHealth>().ReturnToHalfLife();
        gameOverCanvas.SetActive(false);
    }





}
