using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    //---State---
    public int maxLife;
    public int actualLife;
    public int damage;
    public Animator anim;

    private void Start()
    {
        maxLife = 25;
        actualLife = maxLife;
        damage = 10;
        anim = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        if (actualLife <= 0)
        {
            anim.SetTrigger("Dead");
            
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            other.gameObject.GetComponent<PlayerHealth>().DoDamage(damage);

        }
        if (other.gameObject.CompareTag("Bullet"))
        {

            actualLife -= other.gameObject.GetComponent<Bullet>().GetDamageValue();
            AudioController.audioManager.EnemyHurt();
        }
    }

    public void BossDeath()
    {
        GameManager.manager.SetBossKilled();
        AudioController.audioManager.BossDeath();
        this.gameObject.SetActive(false);
    }
}
