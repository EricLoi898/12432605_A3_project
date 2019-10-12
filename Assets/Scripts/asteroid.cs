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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid") { //Bounce off each other to random position
            int code = Random.Range(0, 4);

            string collision_name = collision.gameObject.GetComponent<SpriteRenderer>().sprite.name;
            string obj_name = gameObject.GetComponent<SpriteRenderer>().sprite.name;
            determineCol(obj_name, collision_name);
            switch (code)
            {
                case 0:
                    target = new Vector3(-10, Random.Range(-6f, 6f), 0);
                    break;
                case 1:
                    target = new Vector3(10, Random.Range(-6f, 6f), 0);
                    break;
                case 2:
                    target = new Vector3(Random.Range(-10f, 10f), -6, 0);
                    break;
                case 3:
                    target = new Vector3(Random.Range(-10f, 10f), 6, 0);
                    break;
            }
        }
    }

    private void determineCol(string obj_name, string collision_name)
    {
        //Change the speed of the asteroids based on the size of them
        if (obj_name == "asteroids_0")
        {
            switch (collision_name)
            {
                case "asteroids_0":
                    speed = 5f;
                    break;
                case "asteroids_1":
                    speed = 4f;
                    break;
                case "asteroids_2":
                    speed = 3f;
                    break;
            }
        }
        else if (obj_name == "asteroids_1")
        {
            switch (collision_name)
            {
                case "asteroids_0":
                    speed = 6f;
                    break;
                case "asteroids_1":
                    speed = 5f;
                    break;
                case "asteroids_2":
                    speed = 4f;
                    break;
            }
        }
        else if (obj_name == "asteroids_2")
        {
            switch (collision_name)
            {
                case "asteroids_0":
                    speed = 7f;
                    break;
                case "asteroids_1":
                    speed = 6f;
                    break;
                case "asteroids_2":
                    speed = 5f;
                    break;
            }
        }
    }

    public void takeDamage() {
        HP--;
    }
}
