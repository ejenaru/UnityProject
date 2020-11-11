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

    public void SetDestination(Vector2 room) {
        targetPosition = room;
        CameraMustChange = true;
    }
    //public void GetDestination() { }




    void Update()
    {
        if (CameraMustChange)
        {

            float step = speed * Time.deltaTime;

            // move sprite towards the target location
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);

        } 
    }

}
