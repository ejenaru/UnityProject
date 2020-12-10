using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage = 5;
    //asignarlo al enemy
    private void OnCollisionEnter2D(Collision2D other)
    {
        gameObject.SetActive(false);
        
    }
   public int GetDamageValue()
    {
        return damage;
    }
}
