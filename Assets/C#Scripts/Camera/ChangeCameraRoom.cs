using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script lo lleva el trigger de la puerta
public class ChangeCameraRoom : MonoBehaviour
{
    //----Move CAMERA ---
    public GameObject DestinationRoom; //esta va publica porque se la añadimos en el editor
    private CameraFollowTOP camFollow;

    //-----Move PLAYER ----
    public int verticalDir;
    public int horizontalDir;
    public GameObject player; //esta va privada al final
    public float distanceMovePlayer;  //esta tiene que ir privada al final -- añadir en el start
    Vector3 destinationPlayer;

    //-----Require KEY -----
    public bool keyRequired; //esta va publica para editarla en el editor
    public bool zoomBig;

    //----BossDialog----
    public GameObject dialogScene;
    public InteractionScriptable interactionScene;


    void Start()
    {
        //create 
        destinationPlayer = new Vector3(distanceMovePlayer * horizontalDir, distanceMovePlayer * verticalDir);
        camFollow = Camera.main.GetComponent<CameraFollowTOP>();
        player = GameManager.manager.player;
        this.GetComponent<Collider2D>().isTrigger = !keyRequired;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    { //REQUIRE KEY--------------------------
        //si esta puerta requiere una llave
        if (keyRequired && other.gameObject.CompareTag("Player")) 
        {
            //mira si mi player tiene en el inventario llaves
            if (LootManager.loot.keyNumber > 0)
            {
                LootManager.loot.keyNumber -= 1;
                //--------------------AÑADIR ANIMACION DEPUERTA ABRIENDOSE
                this.gameObject.GetComponent<Collider2D>().isTrigger = true;
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    { //para 
        if (other.CompareTag("Player"))
        {
            camFollow.SetPosition(DestinationRoom); //Coje la habitación hacia la que va y la setea
            other.transform.position+= new Vector3(destinationPlayer.x, destinationPlayer.y,0); //Aplica al player un movimiento
            if (this.name.Equals("GIANT"))
            {
                StartCoroutine(ZoomCamera(10, 18, 0.5f, 200));
            }
            else if (this.name.Equals("SMALL"))
                StartCoroutine(ZoomCamera(18, 10, 0.5f, 200));

        }   
    }
    IEnumerator ZoomCamera(float from, float to, float time, float steps)
    {
        float f = 0;
        bool boss = this.name.Equals("GIANT") && !GameManager.manager.GetBossKilled();

        if (boss)
        {
            //Empieza el dialogo del boss
            GameManager.manager.SetGameDialog();
            GameManager.manager.player.GetComponent<PlayerControllerFRONT>().Movement(0);
        }

        while (f <= 1)
        {
            Camera.main.orthographicSize = Mathf.Lerp(from, to, f);

            f += 1f / steps;

            yield return new WaitForSeconds(time / steps);
            
        }
        if (boss)
        {
            //Empieza el dialogo del boss
            //GameManager.manager.SetGameDialog();
            dialogScene.SetActive(true);
            PrefabDialog.prefabDialogScript.takeScriptable(this.interactionScene);
        }


    }

}
