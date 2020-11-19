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
        //Movement(movH);
        ShootFront(bullet);
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
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("bullet")) other.isTrigger = false;
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
        RaycastHit2D hit;
        float distance = 0;
        float characterWide = 0.5f; //ancho del personaje

        if (_movH < 0)  //ir hacia la izquierda
        {
            hit = Physics2D.Raycast(transform.position - new Vector3(characterWide, 0, 0) , Vector2.left);
        }
        else //if(_movH >0) //
        {
            hit = Physics2D.Raycast(transform.position + new Vector3(characterWide, 0, 0), Vector2.right);
        }

        if (hit.collider != null)
        {
            //Debug.Log("...." + hit.point.x + " ||||  " + transform.position.x);
            distance = Mathf.Abs(hit.point.x - transform.position.x);
            if (distance > 0) distance = 1;
            else distance = 0;
        }
        else distance = 1;


        Debug.Log("distancia: " + distance);
        transform.Translate(transform.right * _movH * Time.deltaTime * speed * distance);
    }


    /*
    void FixedUpdate()
    {
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        // If it hits something...
        if (hit.collider != null)
        {
            // Calculate the distance from the surface and the "error" relative
            // to the floating height.
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            float heightError = floatHeight - distance;

            // The force is proportional to the height error, but we remove a part of it
            // according to the object's speed.
            float force = liftForce * heightError - rb2D.velocity.y * damping;

            // Apply the force to the rigidbody.
            rb2D.AddForce(Vector3.up * force);
        }
    }
    */





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
