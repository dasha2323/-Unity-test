using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LITE : MonoBehaviour
{
    [SerializeField] private Image dimmerImage;
    [SerializeField] private Slider brightnessSlider;
    [SerializeField] private float minBrightnessValue = 0.1f;
    [SerializeField] private string brightnessKey = "Brightness";

    private void Start()
    {
        float savedBrightness = PlayerPrefs.GetFloat(brightnessKey, 1.0f);
        brightnessSlider.value = savedBrightness;
        SetBrightness(savedBrightness);
        brightnessSlider.onValueChanged.AddListener(SetBrightness);
    }

    public void SetBrightness(float value)
    {
        if (dimmerImage != null)
        {
            float brightnessValue = Mathf.Clamp(value, minBrightnessValue, 1f);
            dimmerImage.color = new Color(0, 0, 0, 1 - brightnessValue);
            PlayerPrefs.SetFloat(brightnessKey, brightnessValue);
            PlayerPrefs.Save();
        }
    }
}