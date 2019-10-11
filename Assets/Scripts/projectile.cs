using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    private Vector3 moveStep;
    private float speed = 20f;
    private status status;
    public GameObject explosionSound;
    // Start is called before the first frame update
    void Start()
    {
        status = GameObject.Find("spaceship").GetComponent<status>();
        moveStep = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);//calculate the movement using the position of mouse
        moveStep.z = 0;//Set the z axis into 0 because it is a 2D game
        moveStep.Normalize();//This makes the moveStep vector's magnitude into 1.    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + moveStep * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid")//Increase score when it hits an asteroids then destroy both gameobjects
        {          
            status.score += 10;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "background")//Destroy the projectile when it hits the border of the playfield
        {
            Destroy(gameObject);
        }
    }
}
