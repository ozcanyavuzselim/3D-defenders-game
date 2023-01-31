using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Oyuncunun at�� mekanizmas�n� y�neten script
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
        // Ba�lant�lar� olu�tur
        audio = GetComponent<AudioSource>();
        particle = GetComponent<ParticleSystem>();
        light = GetComponent<Light>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    //merminin at�� xaman�n� ve �izgisini kontrol eder
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

    // At�� yapma fonksiyonu
    void Shoot()
    {
        timer = 0f;
        audio.Play();

        light.enabled = true;
        particle.Stop();
        particle.Play();

        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position);

        // Bir ���n olu�turur
        Ray ray = new Ray();
        RaycastHit hit;
        ray.origin = transform.position;
        ray.direction = transform.forward;

        // E�er ���n bir nesneye �arpt�ysa
        if (Physics.Raycast(ray,out hit , distance))
        {
            // D��man sa�l�k sistemine eri�
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.takeDanage(damage, hit.point);
            }
            lineRenderer.SetPosition(1, hit.point);
        }

    }
}
