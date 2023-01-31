using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//yer çekimini dünyamýzýn merkezine göre ayarlar
public class GravityPlayer : MonoBehaviour
{
    private Rigidbody rigit;
    private GravityReceiver planet;


    private void Awake()
    {
        // Component'ler tanýmlanýr
        rigit = GetComponent<Rigidbody>();
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityReceiver>();
        // Rigidbody'nin kendi yerçekimi kullanmamasý saðlanýr
        rigit.useGravity = false;
        // Rigidbody'nin döndürülmesi engellenir
        rigit.constraints = RigidbodyConstraints.FreezeRotation;
    }


    private void FixedUpdate()
    {
        planet.Receiver(rigit);
    }


}
