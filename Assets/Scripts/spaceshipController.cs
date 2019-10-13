using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceshipController : MonoBehaviour
{
    private Transform player;
    private Animator animator;
    public float speed = 5.0f;
    public GameObject beam;
    public GameObject explosionSound;
    private Vector3 mouse;
    private float fireRate = 0.05f;
    private float nextFire = 0.0f;
    private bool CanShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 120;
        player = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Vector3 tempVect = new Vector3(h, v, 0);
            tempVect = tempVect.normalized * speed * Time.deltaTime;//Make the moveStep vector's magnitude into 1

            player.transform.position += tempVect;
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }

        //Turning according the cursor position
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = new Vector3(
            mouse.x - player.position.x,
            mouse.y - player.position.y
            );
        player.up = direction;

        //Fire
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            Shoot();
        }
    }


    void Shoot()
    {
        if (CanShoot)
        {
            CanShoot = false;
            Instantiate(beam, player.position, Quaternion.identity);//Create a projectile
            AudioSource sound = Instantiate(explosionSound).GetComponent<AudioSource>();//Instantiate the soundManager gameobject
            sound.volume = 0.15f;
            sound.pitch = 2f;
            StartCoroutine(ShootDelay(fireRate));//Limit the time of shots during a period
        }
    }

    IEnumerator ShootDelay(float fireRate)
    {
        yield return new WaitForSeconds(fireRate);
        CanShoot = true;
    }
}
