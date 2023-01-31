using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// oyuncunun ses seviyesini ayarlayan kod dosyasý
public class VolumeSet : MonoBehaviour
{
    private  Slider slider;

    private float volume;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        volume = slider.value;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
