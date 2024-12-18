using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class offmusic : MonoBehaviour
{
    public Button toggleButton; 
    public GameObject imageObject; 

    private bool isImageVisible = false; 

    void Start()
    {
       
        toggleButton.onClick.AddListener(ToggleImageVisibility);
    }

    void ToggleImageVisibility()
    {
        isImageVisible = !isImageVisible; 
        imageObject.SetActive(isImageVisible); 
    }
}
