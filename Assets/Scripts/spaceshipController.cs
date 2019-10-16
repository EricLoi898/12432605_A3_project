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
    public static float fireRate = 0.25f;
    private float nextFire = 0.0f;
    private bool CanShoot = true;
    private float bulletTime = 5f;
    private float timer = 3f;
    private float ratio = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        /*QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 120;*///Use to test whether the game is framerate independent or not
        player = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Count down
        if (timer > 0)
        {
            timer -= Time.unscaledDeltaTime;
            ratio = 1f;
        }
        else
        {
            Time.timeScale = ratio;
        }

        //Movement
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Vector3 tempVect = new Vector3(h, v, 0);
            tempVect = tempVect.normalized * speed * Time.unscaledDeltaTime;//Make the moveStep vector's magnitude into 1

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

        //Trigger Fire
        if (Input.GetMouseButton(0) && Time.unscaledTime > nextFire)
        {
            Shoot();
        }

        //Trigger Bullet time
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bulletTime > 0)
            {
                if (ratio == 1f)
                {
                    ratio = 0.1f;
                }
                else
                {
                    ratio = 1f;
                }
            }
        }

        if (ratio == 0.1f)
        {
            bulletTime -= Time.unscaledDeltaTime;//Counting down
            Debug.Log("BulletTime Left: " + bulletTime);
        }

        if (bulletTime <= 0)
        {
            ratio = 1f;
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
        yield return new WaitForSecondsRealtime(fireRate);
        CanShoot = true;
    }

    public static void addSpeed()
    {
        fireRate /= 1.5f;
    }
}
