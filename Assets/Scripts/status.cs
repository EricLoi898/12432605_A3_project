using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class status : MonoBehaviour
{
    private int HP = 10;
    public static int score = 0;
    public GameObject explosionSound;
    public GameObject pickupSound;
    private UnityEngine.UI.Text HP_txt;
    private UnityEngine.UI.Text score_txt;
    // Start is called before the first frame update
    void Start()
    {
        HP_txt = GameObject.Find("HP").GetComponent<UnityEngine.UI.Text>();
        score_txt = GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update the UI text
        HP_txt.text = "HP: "+ HP.ToString();
        score_txt.text = "Score: " + score.ToString();
        //Press ESC to leave the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("result");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid")//Check whether the collision object is an asteroid
        {
            HP -= 1;
            Instantiate(explosionSound);//Instantiate the soundManager gameobject
            Destroy(collision.gameObject, 0.2f);
            Invoke("endGame", 3);//End game after 3 seconds
        }
        if (collision.gameObject.tag == "item")//Check whether the collision object is an item
        {
            HP += 1;
            Instantiate(pickupSound);//Instantiate the soundManager gameobject
            Destroy(collision.gameObject, 0.2f);
        }
    }

    void endGame()
    {
        if (HP <= 0)
        {
            SceneManager.LoadScene("result");//Go to result page
        }
    }

    public void addScore(int mark)
    {
        score += mark;//Increment the score by passed in mark
    }
}
