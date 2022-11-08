using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerControlls playerControllsScript;

    private float lowerBorder = -20;
    private float upperBorder = 8;
    private float worldLeftBorder = -150;
    private float playerLeftBorder = -23;

    public bool toHigh = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControllsScript = GameObject.Find("Player").GetComponent<PlayerControlls>();
    }

    // Update is called once per frame
    void Update()
    {
        //Platforms are destroyed after they leave the screen
        if (transform.position.x < worldLeftBorder)
        {
            Destroy(gameObject);
        }

        //Player can't be pushed behind the chaser
        if (CompareTag("Player") && transform.position.x < playerLeftBorder)
        {
            rb.AddForce(Vector2.right * 5);
        }

        //Player can't leave the screen upwards and ends the game if they go downwards
        if (transform.position.y < lowerBorder)
        {
            toHigh = false;
            playerControllsScript.gameOver = true;
            Destroy(gameObject);
            Debug.Log("Game Over!");
        }
        else if (transform.position.y > upperBorder)
        {
            rb.AddForce(Vector2.down * 10);
            toHigh = true;
        }
    }
}
