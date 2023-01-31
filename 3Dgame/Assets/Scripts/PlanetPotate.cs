using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bu kod, gezegenin eksen etrafýnda dönmesini saðlar.
public class PlanetPotate : MonoBehaviour
{
    public float speed = 2f;
    
    void Update()
    {
        transform.Rotate(Vector3.up * speed);
    }
}
