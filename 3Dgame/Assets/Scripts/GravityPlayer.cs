using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//yer �ekimini d�nyam�z�n merkezine g�re ayarlar
public class GravityPlayer : MonoBehaviour
{
    private Rigidbody rigit;
    private GravityReceiver planet;


    private void Awake()
    {
        // Component'ler tan�mlan�r
        rigit = GetComponent<Rigidbody>();
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityReceiver>();
        // Rigidbody'nin kendi yer�ekimi kullanmamas� sa�lan�r
        rigit.useGravity = false;
        // Rigidbody'nin d�nd�r�lmesi engellenir
        rigit.constraints = RigidbodyConstraints.FreezeRotation;
    }


    private void FixedUpdate()
    {
        planet.Receiver(rigit);
    }


}
