using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class statusScript : MonoBehaviour
{
    public int HP = 5;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("HP").GetComponent<UnityEngine.UI.Text>().text = "HP: "+ HP.ToString();
        GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>().text = "Score: " + score.ToString();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid")//Check whether the collision object is an asteroid
        {
            HP -= 1;
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            collision.gameObject.GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject, 1.0f);
            Invoke("endGame", 3);//Delay for 3 seconds
        }
    }

    void endGame()
    {
        if (HP <= 0)
        {
            SceneManager.LoadScene("result");
        }
    }
}
