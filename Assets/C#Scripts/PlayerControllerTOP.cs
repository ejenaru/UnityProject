using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTOP : MonoBehaviour
{
    public int life;
    public int score;
    public float speed = 10;

    public GameObject bullet;

    float timeNow;
    float timeLastShoot;
    public float cadency = 2;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeNow = Time.time;
        Movement();
        //Shoot();
        // arreglar colision con propia bullet
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
            score++;
            //añadir sonido de moneda
            Destroy(other.gameObject);
            
        }
        
    }
    public void Movement() //and animation
    {
        float movH = Input.GetAxis("Horizontal");
        transform.Translate(transform.right * movH * Time.deltaTime * speed);
        float movV = Input.GetAxis("Vertical");
        transform.Translate(transform.up * movV * Time.deltaTime * speed);

        if (movH != 0)
        {
            GetComponent<Animator>().SetBool("IsWalkingH", true);
            if (movH > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (movH < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }

        }
        else
        {
            GetComponent<Animator>().SetBool("IsWalkingH", false);
        }
        if (movV != 0)
        {

            if (movV > 0)
            {
                GetComponent<Animator>().SetBool("IsWalkingUp", true);
            }
            else if (movV < 0)
            {
                GetComponent<Animator>().SetBool("IsWalkingDown", true);
            }


        }
        else
        {
            GetComponent<Animator>().SetBool("IsWalkingUp", false);
            GetComponent<Animator>().SetBool("IsWalkingDown", false);
        }
    }
    public void Shoot()
    {
        float shootH = Input.GetAxis("HorizontalShoot");
        float shootV = Input.GetAxis("VerticalShoot");
        if (shootH != 0 && timeNow - timeLastShoot > cadency)
        {
            GameObject bullet_ = Instantiate(bullet, transform.position, transform.rotation);
            Vector2 direction = new Vector2(shootH, 0).normalized;

            timeLastShoot = Time.time;
            bullet_.GetComponent<Rigidbody2D>().velocity = direction * force;
            
        }
        if (shootV != 0 && timeNow - timeLastShoot > cadency)
        {
            GameObject bullet_ = Instantiate(bullet, transform.position, transform.rotation);
            Vector2 direction = new Vector2(0, shootV).normalized;
            timeLastShoot = Time.time;
            bullet_.GetComponent<Rigidbody2D>().velocity = direction * force;
        }
    }
}
