using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasketMovementScript : MonoBehaviour
{
    public float speed;

    int score = 0;
    public Text txtScore;

    // Audio //
    public AudioClip[] AudioClipArr;
    private AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        txtScore.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");

        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

        txtScore.text = "Score: " + score;

        
        if (score >= 100)
        {
            SceneManager.LoadScene("GamePlay_Level 2");
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Healthy")
        {
            audiosource.PlayOneShot(AudioClipArr[0], 0.5f);    
            score += 10;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Unhealthy")
        {
            audiosource.PlayOneShot(AudioClipArr[1], 0.5f);
            SceneManager.LoadScene("GameLoseScene");
        }
    }



}
