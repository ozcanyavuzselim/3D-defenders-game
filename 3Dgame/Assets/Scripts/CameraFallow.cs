using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    public Transform player;
    public float height, lenght;
    public float damp, rotationDemp;

    private void FixedUpdate()
    {
        //kameran�n mesafesi
        Vector3 nexPos = player.TransformPoint(0, height, -lenght);
        transform.position = Vector3.Lerp(transform.position, nexPos, damp * Time.deltaTime);
        
        //kameran�n takibi
        Vector3 dif = player.position - transform.position;
        Quaternion nextPos = Quaternion.LookRotation(dif, player.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, nextPos, rotationDemp * Time.deltaTime);
    }
}
