using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    public Vector3 spawnPos;
    public Vector3 target;
    private float speed = 0.1f;
    private float step;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        step = speed * Time.deltaTime;
        if (spawnPos.x == 10)
        {
            target = new Vector3(-10, Random.Range(-6f,6f), 0);
        }
        else if(spawnPos.x == -10)
        {
            target = new Vector3(10, Random.Range(-6f, 6f), 0);
        }else if(spawnPos.y == 6)
        {
            target = new Vector3(Random.Range(-10f, 10f), -6, 0);
        }
        else if (spawnPos.y == -6)
        {
            target = new Vector3(Random.Range(-10f, 10f), 6, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed);
        if (transform.position == target)
        {
            Destroy(gameObject);
        }
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
