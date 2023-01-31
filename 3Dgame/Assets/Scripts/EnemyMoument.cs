using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoument : MonoBehaviour
{
    private Rigidbody rigid;
    
    private Transform player;
    public float speed = 2f;
    public float enemyspeed = 2f;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Vector3 dir = (player.position - transform.position).normalized; //player ile enemy nin rotasyonunu hesaplamak i�in
        Quaternion newRot = Quaternion.LookRotation(dir, transform.up); ;
        Quaternion smooothRot = Quaternion.Slerp(transform.rotation, newRot, speed * Time.deltaTime);//ak�c� bir �ekilde d�nmesi i�in


        rigid.MoveRotation(smooothRot);//enemy yi player'a d�nd�rmek i�in

        rigid.velocity = transform.forward * enemyspeed * Time.deltaTime*100;//enemy'nin player'a do�ru hareket etmesi i�in


    }
}
