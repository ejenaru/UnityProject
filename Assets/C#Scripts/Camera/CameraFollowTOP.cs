using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTOP : MonoBehaviour
{ 

    public Vector3 targetPosition;
    float speed = 200;

    public bool CameraMustChange;


    private void Start()
    {
        transform.position = GameManager.manager.cameraPosition;
        CameraMustChange = false;
    }
    void Update()
    {
        if (CameraMustChange) ChangeCameraPostion();
         
    }
    public void SetPosition(GameObject room) //
    {
        Vector3 roomVector = new Vector3(room.transform.position.x,room.transform.position.y,0);
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
