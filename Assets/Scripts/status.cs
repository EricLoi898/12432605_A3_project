using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class status : MonoBehaviour
{
    public int HP = 5;
    public int score = 0;
    public GameObject explosionSound;
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
        HP_txt.text = "HP: "+ HP.ToString();
        score_txt.text = "Score: " + score.ToString();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid")//Check whether the collision object is an asteroid
        {
            HP -= 1;
            Instantiate(explosionSound);//Instantiate the soundManager gameobject
            Destroy(collision.gameObject, 0.2f);
            Invoke("endGame", 2);//End game after 2 seconds
        }
    }

    void endGame()
    {
        if (HP <= 0)
        {
            SceneManager.LoadScene("result");
        }
    }

    public void addScore()
    {
        score += 10;
    }
}
