using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{

    Rigidbody2D rb;
    public GameObject arbolesDos;

    //float longitud;
    Vector2 posicionInicial;

    public float speed = 20f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //longitud = arbolesDos.transform.position.x;
        rb.velocity = new Vector2(speed, 0);
        posicionInicial = new Vector2(transform.position.x, transform.position.y);
    }
    private void Update()
    {
        VolverPosicionInicial();
    }

    void VolverPosicionInicial()
    {
        if(arbolesDos.transform.position.x > 0)
        {
            if (transform.position.x > arbolesDos.transform.position.x)
            {
                transform.position = posicionInicial;
            }
        }
        else
        {
            if(transform.position.x < arbolesDos.transform.position.x)
            {
                transform.position = posicionInicial;
            }
        }
    }
}
