using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.UI;  
using TMPro;
public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider; 
    public AudioSource audioSource; 

    public void Start()
    {
        if (volumeSlider != null && audioSource != null)
        {
       
            audioSource.volume = volumeSlider.value;

            
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
        }
    }

    public void ChangeVolume(float value)
    {
        if (audioSource != null)
        {
           
            audioSource.volume = value;
        }
    }

    public void OnDestroy()
    {
        
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
        }
    }
}
