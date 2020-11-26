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
    Rigidbody2D rigidBod;

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
        rigidBod = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //----INPUTS----
        
        movH = Input.GetAxisRaw("Horizontal");
        movV = Input.GetAxisRaw("Vertical");
        shootH = Input.GetAxis("HorizontalShoot");
        shootV = Input.GetAxis("VerticalShoot");

        //---Time related--
        timeNow = Time.time;

        //----Funtions----
        Movement(movH, movV);
        Animation(movH, movV);
        ShootTop(bullet, shootH, shootV);
    }

    public void Movement(float _movH, float _movV)
    {
        
        rigidBod.position += new Vector2(0, _movV * Time.deltaTime * speed);
        rigidBod.position += new Vector2(_movH * Time.deltaTime * speed,0);


        //transform.Translate(transform.right * _movH * Time.deltaTime * speed);
        //transform.Translate(transform.up * _movV * Time.deltaTime * speed);
    }
    public void Animation(float _movH, float _movV)
    {
        if (_movH != 0)
        {
            anim.SetBool("IsWalkingH", true);

            if (_movH > 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (_movH < 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
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
                GameObject bullet = Pooler.pooler.GetPooledObject("Bullet");
                Vector2 direction = new Vector2(shootH, shootV).normalized;
                if (bullet != null)
                {
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    bullet.SetActive(true);
                    bullet.GetComponent<Rigidbody2D>().velocity = direction * force;
                }
                timeLastShoot = Time.time;
            }
        } 
    }
}
