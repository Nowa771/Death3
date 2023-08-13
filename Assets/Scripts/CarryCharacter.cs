using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryCharacter : MonoBehaviour
{
    public GameObject topCharacter;  // The character being carried

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == topCharacter)
        {
            // Set top character's parent to the carrier
            topCharacter.transform.SetParent(transform, true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == topCharacter)
        {
            // Remove top character's parent
            topCharacter.transform.SetParent(null, true);
        }
    }
}




