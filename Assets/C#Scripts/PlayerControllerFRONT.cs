using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFRONT : MonoBehaviour 
{
   //-------------MOVEMENT-------------
    public float speed = 10;

    //------------SHOOT---------------

    public GameObject bullet;

    float timeNow;
    float timeLastShoot;
    public float cadency = 2;
    public float force;

    public Rigidbody2D rigidBod; // el rigidbody guardado.

    public bool isGravityPositive = true; //Aqui guardamos si la gravedad está activada o no
    public bool canIChangeGravity; // Aquí guardamos true si estamos tocando el suelo, porque no queremos poder "volar"

    // Start is called before the first frame update
    void Start()
    {
        rigidBod = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timeNow = Time.time;
        if (Input.GetButtonDown("Jump") && canIChangeGravity) ChangeGravity(); 
        Movement();
        ShootFront(bullet);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "scenario") canIChangeGravity = true;
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
    public void Movement() //and animation
    {
        float movH = Input.GetAxis("Horizontal");
        transform.Translate(transform.right * movH * Time.deltaTime * speed);
    }
    //esta función hace que el personaje DISPARE en horizontal y vertical con las teclas de movimiento.
    public void ShootFront(GameObject bulletToShoot)
    {
        float shootH = Input.GetAxis("HorizontalShoot");
        float shootV = Input.GetAxis("VerticalShoot");
        bool canIShoot = timeNow - timeLastShoot > cadency;
        Vector2 direction;
        //si disparo para los lados y puedo disparar por la cadencia
        if (shootH != 0 && canIShoot)
        {
            // Si estoy en el suelo y disparo parriba OR estoy en el techo y disparo pabajo le doy la dirección en V
            if (isGravityPositive == ((shootV > 0) || shootV == 0)) 
                direction = new Vector2(shootH, shootV).normalized;
            
            else //cuando disparo en contra de la gravedad Y disparo , le doy SOLO la dirección de H para que no deje de disparar
                direction = new Vector2(shootH, 0).normalized;

            GameObject bullet = Instantiate(bulletToShoot, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * force;
            timeLastShoot = Time.time;
        }
    }

    //esta función CAMBIA la direccion de la gravedad del personaje que lo lleva 
    public void ChangeGravity() 
    {
        rigidBod.gravityScale *= -1;
        //devuelve un booleano diciendo si la gravedad está activa o no, puede servir más adelante para darle la vuelta a la animación cuando esté boca abajo o para disparar
        isGravityPositive = !isGravityPositive;
        canIChangeGravity = false;
    }
}
