using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointController : MonoBehaviour
{
    public GameObject room;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            GameManager.manager.UpdateSavePoint(this.transform.position, room);
        }
    }




}
