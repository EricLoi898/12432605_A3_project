using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceshipController : MonoBehaviour
{
    public Transform prefab;
    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        prefab = GameObject.Find("prefab").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.mousePosition);

        Vector3 mousePos = Input.mousePosition;

        Vector2 direction = new Vector2(
            mousePos.x - prefab.position.x,
            mousePos.y - prefab.position.y
            );
        transform.up = direction;
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            prefab.position += new Vector3(0, speed) * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            prefab.position += new Vector3(-speed,0) * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            prefab.position += new Vector3(0, -speed) * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            prefab.position += new Vector3(speed, 0) * Time.fixedDeltaTime;
        }
    }
}
