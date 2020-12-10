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
    Vector2 lookDirection = new Vector2(1, 0);

    //Booleanos
    public bool playerInBedFinale = false;


    void Awake()
    {
        this.transform.position = GameManager.manager.playerStartPosition;
        rigidBod = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.manager.GetBossKilled() && collision.gameObject.name.Equals("Bed"))
        {
            playerInBedFinale = true;
        }
    }
    void Update()
    {
        //----INPUTS----
        
            if (!GameManager.manager.GetGamePause() && !GameManager.manager.GetDialogState())
        {
            movH = Input.GetAxisRaw("Horizontal");
            movV = Input.GetAxisRaw("Vertical");
            shootH = Input.GetAxisRaw("HorizontalShoot");
            shootV = Input.GetAxisRaw("VerticalShoot");

            //---Time related--
            timeNow = Time.time;

            //----Funtions----
            Movement(movH, movV);
            Animation(movH, movV);
            //ShootTop(bullet, shootH, shootV);

        }



        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager.manager.SetGamePause();
        }


    }

    public void Movement(float _movH, float _movV)
    {

        rigidBod.position += new Vector2(0, _movV * Time.deltaTime * speed);
        rigidBod.position += new Vector2(_movH * Time.deltaTime * speed,0);

        //-----Guardar la posición en la que se quedó-----
        if (!Mathf.Approximately(_movV + shootV, 0.0f) || !Mathf.Approximately(_movH + shootH, 0.0f))
        { 
            lookDirection.Set(_movH+shootH, _movV+shootV);
            lookDirection.Normalize();


            //Debug.Log("Maths if movH:" + _movH + ", movV" + _movV +
            //    ", shootH" + shootH + ",ShootV" + shootV + ", lookX " +
            //    lookDirection.x + ", lookY" + lookDirection.y + "");
        }



        //transform.Translate(transform.right * _movH * Time.deltaTime * speed);
        //transform.Translate(transform.up * _movV * Time.deltaTime * speed);


    }
    public void Animation(float _movH, float _movV)
    {
        //----ShootAnim---
        anim.SetBool("Shoot", (shootH + shootV != 0));
        anim.SetFloat("ShootH", shootH);
        anim.SetFloat("ShootV", shootV);
        //----Direction stay anim---
        anim.SetFloat("LookH", lookDirection.x);
        anim.SetFloat("LookV", lookDirection.y);
        //----Moving anim----
        anim.SetBool("Move",((_movH + _movV) != 0));
    }
    public void ShootTop(GameObject bulletToShoot,float _shootH, float _shootV)
    {
        bool canIShoot = timeNow - timeLastShoot > cadency;

        if (canIShoot)
        {
            if (_shootH != 0 || _shootV != 0)
            {
                
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
