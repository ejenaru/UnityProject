using System.Collections;
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

        ShootFront("Bullet1");
    }

    private void FixedUpdate()
    {

        Movement(movH);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //--Gravity--
        if (other.gameObject.tag == "Scenario") canIChangeGravity = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Key"))
        {
            print("TOCANDO MONEDA");
            //GameManager.manager.loot.keyNumber++;
            //GameManager.manager.AddKeyNumber();
            LootManager.loot.AddKeyNumber();
            other.gameObject.SetActive(false);
            GameManager.manager.keyText.text = LootManager.loot.keyNumber.ToString();
        }
    
        if (other.tag.Equals("Platform"))
        {
            transform.SetParent(other.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Platform"))
        {
            transform.SetParent(null);
        }
    }



    //esta función hace que el personaje se mueva en horizontal
    public void Movement(float _movH) //and animation
    {
        //hay que hacerlo con el rigidbody porque el transform interactua mal con las físicas.

        rigidBod.position = (transform.position + transform.right * _movH * Time.deltaTime * speed);
       
        //transform.Translate(transform.right * _movH * Time.deltaTime * speed);
    }

    //esta función hace que el personaje DISPARE en horizontal y vertical con las teclas de movimiento.
    public void ShootFront(string _bulletTag)
    {
        GameObject _bullet = Pooler.pooler.GetPooledObject(_bulletTag);
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
                if (_bullet!= null) //y tiene la tag bullet
                {
                    print("bullet !=null");
                    _bullet.transform.position = transform.position;
                    _bullet.transform.rotation = transform.rotation;
                    _bullet.SetActive(true);
                    _bullet.GetComponent<Rigidbody2D>().velocity = direction * force;
                }
                
                timeLastShoot = Time.time;
            }
            else if ((isGravityPositive && shootV < 0 && shootH != 0) || (!isGravityPositive && shootV > 0 && shootH != 0))
            {
                direction = new Vector2(shootH, 0).normalized;
                if (_bullet != null)
                {
                    _bullet.transform.position = transform.position;
                    _bullet.transform.rotation = transform.rotation;
                    _bullet.SetActive(true);
                    _bullet.GetComponent<Rigidbody2D>().velocity = direction * force;
                }
                
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
