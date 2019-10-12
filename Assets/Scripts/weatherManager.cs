using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weatherManager : MonoBehaviour
{
    private float duration = 0;
    private float shakeMagnitude = 0.1f;
    private float countingSpeed = 1.0f;
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;//Store the original position
        Invoke("Trigger", 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (duration > 0)
        {
            transform.position = transform.position + Random.insideUnitSphere * shakeMagnitude;//Move the camera within a sphere of itself to make the screen shaking

            duration -= Time.deltaTime * countingSpeed;//Decrement the duration
        }
        else
        {
            transform.position = originalPosition;//Reset the camera to original position
        }
    }

    void Trigger()
    {
        if(Random.Range(0,2) == 0) {
            duration = 5f;
        }
        Invoke("Trigger", 30);
    }
}
