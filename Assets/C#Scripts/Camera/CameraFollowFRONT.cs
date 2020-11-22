using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowFRONT : MonoBehaviour
{
    public Transform playerPosition;
    float smooth;
    private Vector3 offset;
    void Start()
    {
        playerPosition = GameManager.manager.player.transform;
        offset = transform.position - playerPosition.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerPosition.transform.position + offset;
    }
}
