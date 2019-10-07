using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    public Vector3 spawnPos;
    public Vector3 target;
    private float speed = 0.2f;
    private float step;
    // Start is called before the first frame update
    void Start()
    {
        /*if (transform.position.x == 10)
        {
            target = new Vector3();
        }
        else
        {
            target = new Vector3();
        }
        step = speed * Time.deltaTime;*/
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, target, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("projectile"))//Check whether the collision object is an asteroid
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
