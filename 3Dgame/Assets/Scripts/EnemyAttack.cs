using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//playerýn ölümü ile ilgili kod dosyasý
public class EnemyAttack : MonoBehaviour
{

    public float nextFire;//düþmanýn saldýrý hýzý
    public int attackDmg = 10;//düþmanýn saldýrý gücü

    private float timer;
    private PlayerHealth playerHealth;
    private bool attackDistance;//saldýrma aralýðý
    private Animator anim;//animatöre ulaþtýk
    private EnemyMoument movement;
    private bool attack;
    private EnemyHealth enemyHealth;


    private void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();//playerdaki scrip'e ulaþtýk
        anim =GetComponent<Animator>();
        movement = GetComponent<EnemyMoument>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >nextFire && attackDistance && attack &&enemyHealth.currentHealth >0 ) //timer deðeri ateþ edeceði deðerden büyük ise saldýracak
        {
            Attack();
        }
        anim.SetBool("Attack", attack);
        //player ölünce animasyonu oynatýr
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
        //can sýfýrdan büyükse saldýrmaya devam edecek
        if (playerHealth.mevcutcan >= 0)
        {
            playerHealth.TakeDamage(attackDmg);
        }
    }



}
