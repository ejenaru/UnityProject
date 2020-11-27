using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowFRONT : MonoBehaviour
{
    public Transform playerPosition;
    float smooth;
    private Vector3 offset;

    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        playerPosition = GameManager.manager.player.transform;
        offset = transform.position - playerPosition.position;
        //ResetCameraPosition();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerPosition.transform.position + offset;
    }


    public void ResetCameraPosition()
    {
        //transform.position = initialPosition;
        transform.position = new Vector3(playerPosition.position.x, playerPosition.position.y, transform.position.z);
        playerPosition = GameManager.manager.player.transform;
        offset = transform.position - playerPosition.position;
    }





}
