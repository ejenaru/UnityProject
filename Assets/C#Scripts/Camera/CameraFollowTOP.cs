using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTOP : MonoBehaviour
{
    //posiciones de la camara en la mazmorra TOP
    //public Vector2 sala1;
    //public Vector2 sala2;

    public Vector3 targetPosition;
    public float speed;

    public bool CameraMustChange;


    private void Start()
    {
        CameraMustChange = false;
    }
    void Update()
    {
        if (CameraMustChange) ChangeCameraPostion();
         
    }
    public void SetPosition(GameObject room) //
    {
        Vector3 roomVector = room.transform.position;
        targetPosition = roomVector; //poner aqui SOLO la posición en x e y de la room
        CameraMustChange = true;
    }
    
    public void ChangeCameraPostion()
    {
        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
