using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//oyun i�erisindeki sayac�n kodlar�
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
        // Oyuncu �lmeden �nce zaman sayac� �al���r
        if (!isDead)
        {
            counter += Time.deltaTime;
            timer.text = " " + counter.ToString("0.0.0");
        }

        // E�er oyuncunun can� s�f�r veya alt�ndaysa, oyuncu �l�r
        if (playerHealth.mevcutcan <= 0 && !isDead)
        {
            isDead = true;
        }

        // E�er oyuncu �l�rse, zaman sayac� "HighScore" keyine kaydedilir
        if (isDead)
        {
            PlayerPrefs.SetFloat("HighScore", counter);
        }
    }
}
