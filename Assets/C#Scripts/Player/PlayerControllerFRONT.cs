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
    //---------ANIMATION----------
    public Rigidbody2D rigidBod; // el rigidbody guardado.
    public SpriteRenderer sprite;
    public Animator anim;
    Vector2 lookDirection = new Vector2(1, 0);

    void Start()
    {
        this.transform.position = GameManager.manager.playerStartPosition;
        rigidBod = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (!GameManager.manager.GetDialogState())
        {
            //---INPUTS---
            movH = Input.GetAxisRaw("Horizontal");
            shootH = Input.GetAxisRaw("HorizontalShoot");
            shootV = Input.GetAxisRaw("VerticalShoot");
            //----SHOOT----
            timeNow = Time.time;
            ShootFront("Bullet");
            //----BUTTONS----
            if (Input.GetButtonDown("Jump") && canIChangeGravity) ChangeGravity();
            //------DEATHS----------
        }



    }

    private void FixedUpdate()
    {
        Animation(movH);
        Movement(movH);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //--Gravity--
        if (other.gameObject.tag.Equals("Scenario") || other.gameObject.tag.Equals("Platform"))
            canIChangeGravity = true;
        if (other.gameObject.tag.Equals("Platform"))
        {
            transform.SetParent(other.transform);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Key"))
        {
            print("TOCANDO MONEDA");
            LootManager.loot.AddKeyNumber();
            other.gameObject.SetActive(false);
            GameManager.manager.keyText.text = LootManager.loot.keyNumber.ToString();
        }
    
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Platform"))
        {
            transform.SetParent(null);
        }
    }
   



    //esta función hace que el personaje se mueva en horizontal
    public void Movement(float _movH) //and animation
    {
        //hay que hacerlo con el rigidbody porque el transform interactua mal con las físicas.

        rigidBod.position = (transform.position + transform.right * _movH * Time.deltaTime * speed);
        if (!Mathf.Approximately(shootV, 0.0f) || !Mathf.Approximately(_movH + shootH, 0.0f))
        {
            lookDirection.Set(_movH + shootH, shootV);
            lookDirection.Normalize();


            Debug.Log("Maths if movH:" + _movH + ", movV" +
                ", shootH" + shootH + ",ShootV" + shootV + ", lookX " +
                lookDirection.x + ", lookY" + lookDirection.y + "");
        }
        //transform.Translate(transform.right * _movH * Time.deltaTime * speed);
    }
    public void Animation(float _movH)
    {
        //----ShootAnim---
        anim.SetBool("Shoot", (shootH + shootV != 0));
        anim.SetFloat("ShootH", shootH);
        anim.SetFloat("ShootV", shootV);
        //----Direction stay anim---
        anim.SetFloat("LookH", lookDirection.x);
        anim.SetFloat("LookV", lookDirection.y);
        //----Moving anim----
        anim.SetBool("Move", ((_movH) != 0));
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
        
        sprite.flipY = !sprite.flipY;
        rigidBod.gravityScale *= -1; //cambiar el signo
        //devuelve un booleano diciendo si la gravedad está activa o no, puede servir más adelante para darle la vuelta a la animación 
        //cuando esté boca abajo o para disparar
        isGravityPositive = !isGravityPositive;
        canIChangeGravity = false;
        AudioController.audioManager.GravityChange();
    }
}
