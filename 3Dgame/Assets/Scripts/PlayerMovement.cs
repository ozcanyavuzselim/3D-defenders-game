using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//karakterin hareketi ve animasyonlarýný yöneten kod dosyasý 
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigit;
    private Vector3 movement;
    private Vector3 moveTarget;
    private Vector3 smoothVelocity;
    private Animator Anim;

    public float speed = 10f;
    public float distance = 100f;
    public LayerMask myLayer;
    public float turnSpeed = 5f;

    void Start()
    {
        rigit = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();

    }

    //hareketlerin klavye tüþlarýna atayan fonksiyon
    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        RotatePlayer();
        AnimatePlayer(h, v);



    }


    // Karakter hareketi
    private void Move(float h, float v)
    {
        movement = new Vector3(h, 0, v).normalized;
        movement = movement * speed * Time.deltaTime;
        moveTarget = Vector3.SmoothDamp(moveTarget, movement, ref smoothVelocity, .10f);


        rigit.MovePosition(rigit.position + transform.TransformDirection(moveTarget));
    }

    //oyuncunun dönüþ hareketini tanýmlayan fonksiyon
    void RotatePlayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, myLayer))
        {
            Vector3 dir = hit.point - transform.position;
            Quaternion newRot = Quaternion.LookRotation(dir,transform.up);
            Quaternion smoothRot = Quaternion.Slerp(transform.rotation, newRot, turnSpeed * Time.deltaTime);


            rigit.MoveRotation(smoothRot);
        }
    }

    //animasyon fonksiyonu
    void AnimatePlayer(float h,float v)
    {
        if (h != 0 || v != 0)
        {
            Anim.SetBool("Run", true);
        }
        else
        {
            Anim.SetBool("Run", false);
        }
    }
}
