using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public PlatformController platformController1;
    public PlatformController platformController2;
    private bool isButtonPressed = false;

    private void Update()
    {
        if (isButtonPressed)
        {
            return; // Exit the update method if the button has been pressed
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isButtonPressed)
        {
            isButtonPressed = true;
            platformController1.TogglePlatform();
            platformController2.TogglePlatform();
            Debug.Log("Button Pressed - Platforms Activated");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isButtonPressed)
        {
            isButtonPressed = false;
            platformController1.LowerPlatform();
            platformController2.LowerPlatform();
            Debug.Log("Player Exited Button Area");
        }
    }
}