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
            other.attachedRigidbody.position+= new Vector2(destinationPlayer.x, destinationPlayer.y); //Aplica al player un movimiento
        }   
    }


}
