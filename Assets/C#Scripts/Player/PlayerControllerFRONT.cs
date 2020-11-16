﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFRONT : MonoBehaviour 
{
    //-------------MOVEMENT-------------
    float movH;
    public float speed = 10;
    public bool isGravityPositive = true; //Aqui guardamos si la gravedad está activada o no
    public bool canIChangeGravity; // Aquí guardamos true si estamos tocando el suelo, porque no queremos poder "volar"

    //------------SHOOT---------------
    float shootH;
    float shootV;

    public GameObject bullet;

    float timeNow;
    float timeLastShoot;
    public float cadency = 2;
    public float force;

    public Rigidbody2D rigidBod; // el rigidbody guardado.

    void Start()
    {
        rigidBod = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //---INPUTS---
        movH = Input.GetAxis("Horizontal");
        shootH = Input.GetAxis("HorizontalShoot");
        shootV = Input.GetAxis("VerticalShoot");
        //----TIME related----
        timeNow = Time.time;
        //----Funtions----
        if (Input.GetButtonDown("Jump") && canIChangeGravity) ChangeGravity(); 
        Movement(movH);
        ShootFront(bullet);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Scenario") canIChangeGravity = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {
            other.isTrigger = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("coin"))
        {
            
            //añadir sonido de moneda
            Destroy(other.gameObject);
            
        }
        
    }

    //esta función hace que el personaje se mueva en horizontal
    public void Movement(float _movH) //and animation
    {
        
        transform.Translate(transform.right * _movH * Time.deltaTime * speed);
    }
    //esta función hace que el personaje DISPARE en horizontal y vertical con las teclas de movimiento.
    public void ShootFront(GameObject bulletToShoot)
    {
        
        bool canIShoot = timeNow - timeLastShoot > cadency;
        Vector2 direction;
        if (canIShoot) //para la cadencia
        {
            //entra si disparo en horizontal y vertical es 0
            if ((shootV == 0 && shootH != 0) ||
                // entra si estoy en suelo y disparo para arriba
                (isGravityPositive && shootV > 0) ||
                // entra si estoy en techo y disparo para abajo
                (!isGravityPositive && shootV < 0))
            {
                //dispara en horizontal
                direction = new Vector2(shootH, shootV).normalized;
                GameObject bullet = Instantiate(bulletToShoot, transform.position, transform.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * force;
                timeLastShoot = Time.time;
            }
            else if ((isGravityPositive && shootV < 0 && shootH != 0) ||
                    (!isGravityPositive && shootV > 0 && shootH != 0))
            {
                direction = new Vector2(shootH, 0).normalized;
                GameObject bullet = Instantiate(bulletToShoot, transform.position, transform.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * force;
                timeLastShoot = Time.time;
            }
            
        }
    }

    //esta función CAMBIA la direccion de la gravedad del personaje que lo lleva 
    public void ChangeGravity() 
    {
        rigidBod.gravityScale *= -1; //cambiar el signo
        //devuelve un booleano diciendo si la gravedad está activa o no, puede servir más adelante para darle la vuelta a la animación 
        //cuando esté boca abajo o para disparar
        isGravityPositive = !isGravityPositive;
        canIChangeGravity = false;
    }
}