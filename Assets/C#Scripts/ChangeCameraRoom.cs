using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraRoom : MonoBehaviour
{
    public Vector2 DestinationRoom;
    //Este script lo lleva el trigger de la puerta

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Camera.main.GetComponent<CameraFollowTOP>().SetDestination(DestinationRoom);//A esta funcion quiero darle un número. El número de la habitación a la que vaya
        }   
    }
}
