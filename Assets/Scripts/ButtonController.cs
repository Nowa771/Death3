using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public PlatformController platformController;
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
            platformController.TogglePlatform();
            Debug.Log("Button Pressed - Platform Activated");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isButtonPressed)
        {
            isButtonPressed = false;
            platformController.LowerPlatform();
            Debug.Log("Player Exited Button Area");
        }
    }
}
