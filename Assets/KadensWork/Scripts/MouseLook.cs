using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    public Slider slider;
    public float mouseSensitivity;
    public Transform playerRb;
    float xRotation = 0f;

    void Start()
    {
       
        mouseSensitivity = PlayerPrefs.GetFloat("currentSensitivity", 5);
        slider.minValue = 10;
        slider.maxValue = 300;
        slider.value = mouseSensitivity;
        

        // Add an event listener to the slider's onValueChanged event
        slider.onValueChanged.AddListener(AdjustSpeed);
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.fixedDeltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerRb.Rotate(Vector3.up * mouseX);
    }

    // This method will be called when the slider's value is changed
    public void AdjustSpeed(float newSpeed)
    {
        mouseSensitivity = newSpeed;
        PlayerPrefs.SetFloat("currentSensitivity", mouseSensitivity);
    }
}

