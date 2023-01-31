using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player�n �l�m� ile ilgili kod dosyas�
public class EnemyAttack : MonoBehaviour
{

    public float nextFire;//d��man�n sald�r� h�z�
    public int attackDmg = 10;//d��man�n sald�r� g�c�

    private float timer;
    private PlayerHealth playerHealth;
    private bool attackDistance;//sald�rma aral���
    private Animator anim;//animat�re ula�t�k
    private EnemyMoument movement;
    private bool attack;
    private EnemyHealth enemyHealth;


    private void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();//playerdaki scrip'e ula�t�k
        anim =GetComponent<Animator>();
        movement = GetComponent<EnemyMoument>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >nextFire && attackDistance && attack &&enemyHealth.currentHealth >0 ) //timer de�eri ate� edece�i de�erden b�y�k ise sald�racak
        {
            Attack();
        }
        anim.SetBool("Attack", attack);
        //player �l�nce animasyonu oynat�r
        if (playerHealth.mevcutcan <=0)
        {
            anim.SetTrigger("PlayerDead");
            movement.enabled = false;
            attack = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            attackDistance = true;
            attack = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            attackDistance = false;
            attack = false;
        }
    }

    private void Attack()
    {
        timer = 0f;

        anim.SetBool("Attack", attack);
        //can s�f�rdan b�y�kse sald�rmaya devam edecek
        if (playerHealth.mevcutcan >= 0)
        {
            playerHealth.TakeDamage(attackDmg);
        }
    }



}
