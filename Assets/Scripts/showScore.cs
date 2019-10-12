using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showScore : MonoBehaviour
{
    private status status;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<UnityEngine.UI.Text>().text = "Score: " + status.score;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
