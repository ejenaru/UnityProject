using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //---State---

    public int life;
    public int damage;
    public float speed;
    public float attackRange;
    public Transform playerPosition;
    public Transform enemyPosition;
    public Rigidbody2D enemyRigid;

    private void Start()
    {
        playerPosition = GameManager.manager.player.transform;
        enemyPosition = transform;
        enemyRigid = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //miro si estoy cerca del player para moverme hacia él.
        if ((transform.position - playerPosition.position).magnitude < attackRange)
        {
             enemyRigid.position += (new Vector2((playerPosition.position - enemyPosition.position).normalized.x, 
                 (playerPosition.position - enemyPosition.position).normalized.y) 
                * speed * Time.deltaTime);
        }
    }
}
