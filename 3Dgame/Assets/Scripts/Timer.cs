using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//oyun içerisindeki sayacýn kodlarý
public class Timer : MonoBehaviour
{
    private Text timer;
    private float counter;
    private PlayerHealth playerHealth;
    private bool isDead = false;

    private void Awake()
    {
        timer = GetComponent<Text>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void FixedUpdate()
    {
        // Oyuncu ölmeden önce zaman sayacý çalýþýr
        if (!isDead)
        {
            counter += Time.deltaTime;
            timer.text = " " + counter.ToString("0.0.0");
        }

        // Eðer oyuncunun caný sýfýr veya altýndaysa, oyuncu ölür
        if (playerHealth.mevcutcan <= 0 && !isDead)
        {
            isDead = true;
        }

        // Eðer oyuncu ölürse, zaman sayacý "HighScore" keyine kaydedilir
        if (isDead)
        {
            PlayerPrefs.SetFloat("HighScore", counter);
        }
    }
}
