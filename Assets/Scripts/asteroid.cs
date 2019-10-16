using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    private Vector3 spawnPos;
    private Vector3 target;
    private float speed = 7.5f;
    private int HP;
    private status status;
    private string sprite_name;
    public GameObject[] prefabs;
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
  

    }

    void FixedUpdate()
    {
        if (HP == 0)
        {
            //Add score based on the size of asteroids
            if (sprite_name == "asteroid_0")
            {
                status.addScore(50);
                crack(0);
                crack(1);
                drop();
                Destroy(gameObject);
            }
            else if (sprite_name == "asteroid_1")
            {
                status.addScore(30);
                crack(0);
                crack(0);
                Destroy(gameObject);
            }
            else if (sprite_name == "asteroid_2")
            {
                status.addScore(10);
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid") { //Bounce off each other to random position
            int code = Random.Range(0, 4);

            string collision_name = collision.gameObject.GetComponent<SpriteRenderer>().sprite.name;
            determineCol(collision_name);
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

    private void determineCol(string collision_name)
    {
        //Change the speed of the asteroids based on the size of them
        if (sprite_name == "asteroid_0")
        {
            switch (collision_name)
            {
                case "asteroid_0":

                    break;
                case "asteroid_1":
                    speed -= 1f;
                    break;
                case "asteroid_2":
                    speed -= 2f;
                    break;
            }
        }
        else if (sprite_name == "asteroid_1")
        {
            switch (collision_name)
            {
                case "asteroid_0":
                    speed += 1f;
                    break;
                case "asteroid_1":

                    break;
                case "asteroid_2":
                    speed -= 1f;
                    break;
            }
        }
        else if (sprite_name == "asteroid_2")
        {
            switch (collision_name)
            {
                case "asteroid_0":
                    speed += 2f;
                    break;
                case "asteroid_1":
                    speed += 1f;
                    break;
                case "asteroid_2":

                    break;
            }
        }
    }

    void crack(int code)
    {
        Instantiate(prefabs[code], transform.position, Quaternion.identity);//Crack into smaller asteroids
    }

    void drop()
    {
        if (sprite_name == "asteroid_0") {
        int code1 = Random.Range(0, 5);
        int code2 = Random.Range(0, 10);
        if (code1 == 0)
        {
            Instantiate(prefabs[2], transform.position, Quaternion.identity);//Drop a spanner
        }else if (code2 == 0)
        {
            Instantiate(prefabs[3], transform.position, Quaternion.identity);//Drop an ammo
        }
        }
    }

    public void takeDamage() {
        HP--;
    }
}
