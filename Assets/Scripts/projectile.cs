using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    private Vector3 target;
    public float speed = 40.0f;
    // Start is called before the first frame update
    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position == target) {
            Destroy(gameObject);
        }
    }
}
