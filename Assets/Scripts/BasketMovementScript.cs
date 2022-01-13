using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketMovementScript : MonoBehaviour
{
    public float speed;

    int score = 0;
    public Text txtScore;
   
    // Start is called before the first frame update
    void Start()
    {
        txtScore.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {

      float horizontalInput = Input.GetAxis("Horizontal");

      transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);


        txtScore.text = "Score: " + score;

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
            print("dead");
        }
    }



}
