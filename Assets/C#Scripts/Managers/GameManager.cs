using System.Collections;
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
    public GameObject PlayerPrefab;
    //-------GUARDAR AL CAMBIAR DE ROOM----
    private Vector3 initialPosition = new Vector3(-0.5f, 2f, 0);
    public Vector3 playerStartPosition; //La posición que toma el personaje al pasar por el trigger
    public Vector3 cameraPosition;
    public int currentScene;

    //------ESTADO GAME---------
    private bool gamePause = false;
    private bool dialogState = false;
    public GameObject pauseCanvas;
    public GameObject canvas;
    GameObject pauseObject = null;

    public Text keyText;

    //private gameState;  //0 - menu, 1 - dialog, 2 - battle, 3 - world, 4 - dungeon 



    private void Awake()
    {

        manager = this; //singletone
        DontDestroyOnLoad(this.gameObject);
        //Voy a guardar aqui el player para usarlo en varias ocasiones, así no tengo que hacer el findgameobject más veces.
        player = GameObject.FindWithTag("Player");
        
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
        if (Input.GetKeyDown(KeyCode.K))
        {
            KillPlayer();
            AudioController.audioManager.DeathSpikes();
        }
    }


    #region SceneManagement
    public void LoadLevel(int sceneToLoad) //Función a la que debemos INDICAR mediante un INT el nº de escena que queremos cargar

    {

        //aqui hacemos el fade para la pantalla de carga.

        currentScene = SceneManager.GetActiveScene().buildIndex; //devuelve en nº de escena y lo guarda 
        //hacer aqui una tansicion a negro y despues cargar la escena

        SceneManager.LoadScene(sceneToLoad);

        /*switch (sceneType)
        {
            case Dunge

            ca
        }*/


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
        gamePause = !gamePause;
        //activar canvas de pausa
        
        if (pauseObject == null) pauseObject = Instantiate(pauseCanvas, canvas.transform) as GameObject;
        else
        {
            Destroy(pauseObject);
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


    #region SavePoint
    public void UpdateSavePoint(Vector3 newPosition)
    {
        playerStartPosition = new Vector3(newPosition.x, newPosition.y, 0);   //ponemos la Z a 0 porque el sistema de particulas está en z=-12
    }


    #endregion



    public void KillPlayer()
    {
        print("KILL PLAYER");
        Destroy(player);
        player = Instantiate(PlayerPrefab, playerStartPosition, Quaternion.identity);
        //cam.GetComponent<CameraFollowTOP>().ResetCameraPosition();


    }





}
