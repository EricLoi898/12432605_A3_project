using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{
    public float spawnSpeed = 0.1f;
    private Vector3 spawnPos;
    private int[] x_axes = {10, -10};
    private int[] y_axes = {6, -6};

    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void spawn()
    {
        if(Random.Range(0,2)== 0)
        {
            spawnPos = new Vector3(x_axes[Random.Range(0, 2)], Random.Range(-6f, 6f));
        }
        else
        {
            spawnPos = new Vector3(Random.Range(-10f, 10f), y_axes[Random.Range(0, 2)]);
        }      
        Instantiate(prefab, spawnPos, Quaternion.identity);
        Invoke("spawn", spawnSpeed);
    }
}
