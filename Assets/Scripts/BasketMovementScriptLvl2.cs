using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasketMovementScriptLvl2 : MonoBehaviour
{
    public float speed;

    int score = 0;
    public Text txtScore;
    public Text txtTimer;

    int TimerInt;
    float timer = 30;


    // Start is called before the first frame update
    void Start()
    {
        txtScore.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        // Timer
        timer -= Time.deltaTime;
        TimerInt = Mathf.FloorToInt(timer % 30);
        txtTimer.text = "Timer: " + TimerInt.ToString();

        // Lvl 2 Win Condition //
        if (TimerInt <= 0)
        {
            SceneManager.LoadScene("GameWinScene");
        }

        float horizontalInput = Input.GetAxis("Horizontal");

        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

        txtScore.text = "Score: " + score;


        //if (score >= 100)
        //{
        //    SceneManager.LoadScene("GamePlay_Level 2");
        //}


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Healthy")
        {
            score += 10;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Unhealthy")
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }
}
