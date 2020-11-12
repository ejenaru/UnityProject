using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTOP : MonoBehaviour
{
    public int life = 8; //4 corazones de vida
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
        
    }

    // Update is called once per frame
    void Update()
    {
        timeNow = Time.time;
        Movement();
        ShootTop();
        // arreglar colision con propia bullet
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
    public void ShootTop()
    {
        float shootH = Input.GetAxis("HorizontalShoot");
        float shootV = Input.GetAxis("VerticalShoot");
        bool canIShoot = timeNow - timeLastShoot > cadency;

        if (canIShoot)
        {
            if (shootH != 0 || shootV != 0)
            {
                GameObject bullet_ = Instantiate(bullet, transform.position, transform.rotation);
                Vector2 direction = new Vector2(shootH, shootV).normalized;
                timeLastShoot = Time.time;
                bullet_.GetComponent<Rigidbody2D>().velocity = direction * force;

            }
            
        }
        
    }
}
