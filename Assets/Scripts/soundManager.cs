using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy itself when the audio has been played
        if(gameObject.GetComponent<AudioSource>().isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
