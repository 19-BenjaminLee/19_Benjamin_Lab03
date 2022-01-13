using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectMovement : MonoBehaviour
{
    private float ySpeed = -4f;
    // Start is called before the first frame update
    void Start()
    {
        // Falling speed per level //

        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "GamePlay_Level 1")
        {
            ySpeed = -4f;
        }

        else if (sceneName == "GamePlay_Level 2")
        {
            ySpeed = -7f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        transform.Translate(new Vector3(0f, ySpeed * Time.deltaTime, 0f));
        if (transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }
}
