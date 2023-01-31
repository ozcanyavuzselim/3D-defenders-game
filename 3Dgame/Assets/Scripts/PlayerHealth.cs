using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float startHealth = 200f;
    public float mevcutcan;
    public Slider canSlider;
    public AudioClip DeadClip;
    public Image hurtImg;
    public float speed =2f;

    private AudioSource audio;
    private bool isDead,hurt;

    private void Awake()
    {
        mevcutcan = startHealth;//baþlangiç caný ile mevcut caný eþitledik
        audio = GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        if (hurt)
        {
            hurtImg.color = new Color(1f, 0f, 0f, 0.4f);//saldýrý esanasýnda ekran rengini deðiþtirir
        }
        else
        {
            hurtImg.color = Color.Lerp(hurtImg.color, Color.clear, speed * Time.deltaTime);//ekran rengini eski halýne getirir
        }
        hurt = false;
    }
    public void TakeDamage(int damage)
    {
        hurt = true;

        mevcutcan -= damage;//hasar gelince mevcut caný düþürmek
        canSlider.value = mevcutcan;

        audio.Play();

        if (mevcutcan <=0 && !isDead)
        {
            Die();
        }

       
    }

    //ölüm ve sonrasý
    private void Die()
    {
        //karakterin yokolmasý
        isDead = true;
        transform.gameObject.SetActive(false);

        audio.clip = DeadClip;//müzik çalýþtýrma
        audio.Play();
    }

}
