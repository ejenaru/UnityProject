using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //asignarlo al enemy
    private void OnCollisionEnter2D(Collision2D other)
    {
        gameObject.SetActive(false);
    }
   
}
