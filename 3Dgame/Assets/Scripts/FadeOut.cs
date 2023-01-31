using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    // Süre boyunca nasýl sola doðru kaydýrýlacaðý belirlenir
    public float fadeTime;

    // Görsel element tanýmlanýr
    private Image fadeImage;
    private Color myColor = Color.black;

    private void Awake()
    {
        // Component tanýmlanýr
        fadeImage = GetComponent<Image>();
    }

    private void Update()
    {
        // Eðer seviye yüklenmeden önce geçen süre belirtilen süreden kýsaysa
        if (Time.timeSinceLevelLoad <fadeTime)
        {
            // Alpha deðeri belirtilen süreye oranla hesaplanýr
            float alpha = Time.deltaTime / fadeTime;
            myColor.a -= alpha;
            fadeImage.color = myColor;
        }
        else
        {
            // Eðer belirtilen süre geçildiyse, görsel element etkinliði kapatýlýr
            gameObject.SetActive(false);
        }
    }
}
