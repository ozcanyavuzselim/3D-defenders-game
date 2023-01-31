using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    // S�re boyunca nas�l sola do�ru kayd�r�laca�� belirlenir
    public float fadeTime;

    // G�rsel element tan�mlan�r
    private Image fadeImage;
    private Color myColor = Color.black;

    private void Awake()
    {
        // Component tan�mlan�r
        fadeImage = GetComponent<Image>();
    }

    private void Update()
    {
        // E�er seviye y�klenmeden �nce ge�en s�re belirtilen s�reden k�saysa
        if (Time.timeSinceLevelLoad <fadeTime)
        {
            // Alpha de�eri belirtilen s�reye oranla hesaplan�r
            float alpha = Time.deltaTime / fadeTime;
            myColor.a -= alpha;
            fadeImage.color = myColor;
        }
        else
        {
            // E�er belirtilen s�re ge�ildiyse, g�rsel element etkinli�i kapat�l�r
            gameObject.SetActive(false);
        }
    }
}
