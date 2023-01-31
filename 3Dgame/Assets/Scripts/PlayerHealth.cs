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
        mevcutcan = startHealth;//ba�langi� can� ile mevcut can� e�itledik
        audio = GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        if (hurt)
        {
            hurtImg.color = new Color(1f, 0f, 0f, 0.4f);//sald�r� esanas�nda ekran rengini de�i�tirir
        }
        else
        {
            hurtImg.color = Color.Lerp(hurtImg.color, Color.clear, speed * Time.deltaTime);//ekran rengini eski hal�ne getirir
        }
        hurt = false;
    }
    public void TakeDamage(int damage)
    {
        hurt = true;

        mevcutcan -= damage;//hasar gelince mevcut can� d���rmek
        canSlider.value = mevcutcan;

        audio.Play();

        if (mevcutcan <=0 && !isDead)
        {
            Die();
        }

       
    }

    //�l�m ve sonras�
    private void Die()
    {
        //karakterin yokolmas�
        isDead = true;
        transform.gameObject.SetActive(false);

        audio.clip = DeadClip;//m�zik �al��t�rma
        audio.Play();
    }

}
