using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//random enemy spawn eden kod dosyas�
public class EnemySpavner : MonoBehaviour
{
    public GameObject enemy;
    public PlayerHealth playerHealth;
    public Transform[] spawnPoint;

    public float spawnTime = 3f;


    private void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);//oyun ba�lad�ktan sonra belirlenen s�rede fonksiyonu �a��r
    }

    private void Spawn()
    {
        //Enemyyi spawn eden fonksiyon
        if (playerHealth.mevcutcan <= 0)
            return;

            int index = Random.Range(0, spawnPoint.Length);

            Instantiate(enemy, spawnPoint[index].position, spawnPoint[index].rotation);
        
    }
}
