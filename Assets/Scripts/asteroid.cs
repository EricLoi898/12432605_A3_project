using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    private Vector3 spawnPos;
    private Vector3 target;
    private float speed = 5f;
    private int HP;
    private status status;
    private string sprite_name;
    // Start is called before the first frame update
    void Start()
    {
        status = GameObject.Find("spaceship").GetComponent<status>();
        sprite_name = gameObject.GetComponent<SpriteRenderer>().sprite.name;
        if (sprite_name == "asteroid_0")
        {
            HP = 3;
        }else if (sprite_name == "asteroid_1")
        {
            HP = 2;
        }else if (sprite_name == "asteroid_2")
        {
            HP = 1;
        }

        spawnPos = transform.position;
        //Move asteroids to the other side of the map
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
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position == target)
        {
            Destroy(gameObject);
        }
        if (HP == 0)
        {
            status.addScore();
            Destroy(gameObject);
        }

    }
    public void takeDamage() {
        HP--;
    }
}
