using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int startHealth = 100;
    public int currentHealth;
    public AudioClip deatClip;

    private Animator anim;
    private AudioSource audio;
    private ParticleSystem particel;
    private bool isDead;
    private CapsuleCollider col;
    private EnemyMoument EnemyMoument;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        currentHealth = startHealth;
        particel = GetComponentInChildren<ParticleSystem>();
        col = GetComponent<CapsuleCollider>();
        EnemyMoument = GetComponent<EnemyMoument>();
    }
    public void takeDanage(int dmg,Vector3 hitPoint)
    {
        if (isDead)
        {
            return;
        }
        audio.Play();
        currentHealth -= dmg;

        particel.transform.position = hitPoint;
        particel.Play();

        if (currentHealth <=0)
        {
            Die();

        }
    }
    //�l�nce olacak �eyler
    void Die()
    {
        EnemyMoument.enabled = false;
        isDead = true;
       // col.enabled = false;//d��mana �arpmay� �nler
        anim.SetTrigger("EnemyDead");   //animasyon �al��t�rma
        //�l�m sesi  
        audio.clip = deatClip;
        audio.Play();

    }

}
