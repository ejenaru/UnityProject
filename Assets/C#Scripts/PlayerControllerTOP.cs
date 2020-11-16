using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Este script lo lleva el player que se ve desde arriba
[RequireComponent(typeof(Animator))]
public class PlayerControllerTOP : MonoBehaviour
{
    //-----MOVEMENT---
    public float speed = 10;
    float movH;
    float movV;

    //-----SHOOT-----
    float shootH;
    float shootV;

    public GameObject bullet;
    float timeNow;
    float timeLastShoot;
    public float cadency = 2;
    public float force;

    //-------Animator-----
    private Animator anim;

    
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //----INPUTS----
        movH = Input.GetAxis("Horizontal");
        movV = Input.GetAxis("Vertical");
        shootH = Input.GetAxis("HorizontalShoot");
        shootV = Input.GetAxis("VerticalShoot");

        //---Time related--
        timeNow = Time.time;

        //----Funtions----
        Movement(movH, movV);
        ShootTop(bullet, shootH, shootV);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //Las balas por defecto son Trigger para no mover al personaje, cuando salen del personaje son colliders
        if (other.gameObject.CompareTag("Bullet")) other.isTrigger = false; 
    }

    public void Movement(float _movH, float _movV) //and animation
    {
        transform.Translate(transform.right * _movH * Time.deltaTime * speed);
        
        transform.Translate(transform.up * _movV * Time.deltaTime * speed);

        if (_movH != 0)
        {
            anim.SetBool("IsWalkingH", true);

            if (_movH > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (_movH < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else anim.SetBool("IsWalkingH", false);

        if (_movV != 0)
        {
            if (_movV > 0) anim.SetBool("IsWalkingUp", true);
            else if (_movV < 0) anim.SetBool("IsWalkingDown", true);
        }
        else
        {
            anim.SetBool("IsWalkingUp", false);
            anim.SetBool("IsWalkingDown", false);
        }
    }
    public void ShootTop(GameObject bulletToShoot,float _shootH, float _shootV)
    {
        bool canIShoot = timeNow - timeLastShoot > cadency;

        if (canIShoot)
        {
            if (_shootH != 0 || _shootV != 0)
            {//aqui hay que hacer un pool
                GameObject bullet_ = Instantiate(bulletToShoot, transform.position, transform.rotation);
                Vector2 direction = new Vector2(shootH, shootV).normalized;
                timeLastShoot = Time.time;
                bullet_.GetComponent<Rigidbody2D>().velocity = direction * force;
            }
        } 
    }
}
