using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerControlls playerControllsScript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControllsScript = GameObject.Find("Player").GetComponent<PlayerControlls>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -150)
        {
            Destroy(gameObject);
        }

        if (transform.position.y < -20)
        {
            Destroy(gameObject);
            playerControllsScript.gameOver = false;
            Debug.Log("Game Over!");
        }
        else if (transform.position.y > 10)
        {
            rb.AddForce(Vector2.down * 10);
        }
    }
}
