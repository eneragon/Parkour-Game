using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Startup : MonoBehaviour
{
    public Slider mouse_slider;
    //Set Mouse Sensitivity on Player and Slider
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 200);
        mouse_slider.value = PlayerPrefs.GetFloat("MouseSensitivity", 200);
    }
}
