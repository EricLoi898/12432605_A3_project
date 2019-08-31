using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceshipController : MonoBehaviour
{
    public Transform prefab;
    public Animator animator;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        prefab = GameObject.Find("spaceship").GetComponent<Transform>();
        animator = GameObject.Find("spaceship").GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //Turning according the cursor position
        /*Debug.Log(Input.mousePosition);

        Vector3 mousePos = Input.mousePosition;

        Vector2 direction = new Vector2(
            mousePos.x - prefab.position.x,
            mousePos.y - prefab.position.y
            );
        prefab.up = direction;*/
    }
    void FixedUpdate()
    {
        //Movement
        if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D))
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Vector3 tempVect = new Vector3(h, v, 0);
            tempVect = tempVect.normalized * speed * Time.deltaTime;

            prefab.transform.position += tempVect;
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            //Fire();
        }
    }
}
