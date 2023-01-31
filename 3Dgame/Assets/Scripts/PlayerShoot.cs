using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Oyuncunun atýþ mekanizmasýný yöneten script
public class PlayerShoot : MonoBehaviour
{

    public float nextFire = 0.2f;
    public int damage =25;
    public float distance = 5f;

    private float timer;
    private AudioSource audio;
    private ParticleSystem particle;
    private Light light;
    private LineRenderer lineRenderer;
    private float effecktTime = 0.2f;

    private void Awake()
    {
        // Baðlantýlarý oluþtur
        audio = GetComponent<AudioSource>();
        particle = GetComponent<ParticleSystem>();
        light = GetComponent<Light>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    //merminin atýþ xamanýný ve çizgisini kontrol eder
    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1")&& timer > nextFire)
        {
            Shoot();
        }

        if (timer > nextFire*effecktTime)
        {

            lineRenderer.enabled = false;
            light.enabled = false;

        }
    }

    // Atýþ yapma fonksiyonu
    void Shoot()
    {
        timer = 0f;
        audio.Play();

        light.enabled = true;
        particle.Stop();
        particle.Play();

        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position);

        // Bir ýþýn oluþturur
        Ray ray = new Ray();
        RaycastHit hit;
        ray.origin = transform.position;
        ray.direction = transform.forward;

        // Eðer ýþýn bir nesneye çarptýysa
        if (Physics.Raycast(ray,out hit , distance))
        {
            // Düþman saðlýk sistemine eriþ
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.takeDanage(damage, hit.point);
            }
            lineRenderer.SetPosition(1, hit.point);
        }

    }
}
