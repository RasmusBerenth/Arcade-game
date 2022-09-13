using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerControlls playerControllsScript;

    private float lowerBorder = -20;
    private float upperBorder = 10;
    private float leftBorder = -150;

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
        if (transform.position.x < leftBorder)
        {
            Destroy(gameObject);
        }

        //Player can't leave the screen upwards and ends the game if they go downwards
        if (transform.position.y < lowerBorder)
        {
            playerControllsScript.gameOver = true;
            Destroy(gameObject);
            Debug.Log("Game Over!");
        }
        else if (transform.position.y > upperBorder)
        {
            rb.AddForce(Vector2.down * 10);
        }
    }
}