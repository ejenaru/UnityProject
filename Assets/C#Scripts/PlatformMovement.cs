using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PlatformMovement : MonoBehaviour
{
    public Vector3 initialPosition;
    
    public Transform finalPosition; //solo el valor de X
    public int speed = 10;
    float distance;
    
    // Start is called before the first frame update
    void Start()
    {
        
        initialPosition = this.gameObject.transform.position;
        distance = finalPosition.position.x - initialPosition.x;
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Jump")) StartCoroutine(Move());
        //if (Input.GetButtonDown("Jump")) this.gameObject.transform.position = new Vector3(initialPosition.x + (Mathf.PingPong(Time.time * speed, distance)), initialPosition.y, initialPosition.z);

        //this.gameObject.transform.position = new Vector3(initialPosition.x  + (Mathf.PingPong(Time.time * speed, distance)), initialPosition.y, initialPosition.z);
        //PingPong es una función que en realidad es una minicorrutina. Devuelve 
        //También se pued ehacer con el movetowards

       
    }
    IEnumerator Move()
    {
        print("INICIO MOVE()");
        while (true) //podria meter una condicion para compaginarla con la otra plataforma.
        {
            for (int i = 0; i < 100; i++)
            {
                this.gameObject.transform.position += new Vector3((distance / 100), 0);
                Debug.Log("{0} DENTRO AVANZAR" + i);

                yield return new WaitForSeconds(1 * Time.deltaTime);
            }
            for (int i = 0; i < 100; i++)
            {
                this.gameObject.transform.position -= new Vector3((distance / 100), 0);
                Debug.Log("{0} DENTRO RETROCEDER" + i);

                yield return new WaitForSeconds(1 * Time.deltaTime);
            }
            print("FUERA DE BUCLE FOR");


        }
    }
    

    IEnumerator Example()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
