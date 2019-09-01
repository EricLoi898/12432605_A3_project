using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceshipController : MonoBehaviour
{
    private Transform player;
    private Animator animator;
    public float speed = 5.0f;
    public GameObject beam;
    private Vector3 mouse;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Turning according the cursor position
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = new Vector3(
            mouse.x - player.position.x,
            mouse.y - player.position.y
            );
        player.up = direction;

        //Fire
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(beam, player.position, Quaternion.identity);
        }
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

            player.transform.position += tempVect;
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
}
