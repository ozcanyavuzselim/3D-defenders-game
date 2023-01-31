using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bu kod, gezegenin eksen etraf�nda d�nmesini sa�lar.
public class PlanetPotate : MonoBehaviour
{
    public float speed = 2f;
    
    void Update()
    {
        transform.Rotate(Vector3.up * speed);
    }
}
