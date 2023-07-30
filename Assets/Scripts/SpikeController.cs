using UnityEngine;
using System.Collections;

public class SpikeController : MonoBehaviour
{
    public float timeToToggleSpike = 2;
    public float currentTime = 0;
    public bool enabled = true;

    void Start()
    {
        enabled = true;
    }

    void Update()
    {
        currentTime += Time.deltaTime; 
        if (currentTime >= timeToToggleSpike)
        {
            currentTime = 0;
            ToggleSpike(); 
        }
    }

    void ToggleSpike()
    {
        enabled = !enabled;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(enabled);
        }
    }
}




