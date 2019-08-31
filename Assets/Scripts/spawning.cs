using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{
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
        
        Instantiate(prefab, new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0), Quaternion.identity);
        Invoke("spawn",2);
    }
}
