using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerControlls playerControllsScript;

    [SerializeField] private float lowerBorder = -20;
    [SerializeField] private float upperBorder = 8;
    [SerializeField] private float worldLeftBorder = -150;
    [SerializeField] private float playerLeftBorder = -23;
    [SerializeField] private float upperForce = 10;
    [SerializeField] private float leftForce = 5;

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
            rb.AddForce(Vector2.right * leftForce);
        }

        //Player can't leave the screen upwards and ends the game if they go downwards
        if (transform.position.y < lowerBorder)
        {
            toHigh = false;
            playerControllsScript.gameOver = true;
            Destroy(gameObject);
        }
        else if (transform.position.y > upperBorder)
        {
            rb.AddForce(Vector2.down * upperForce);
            toHigh = true;
        }
    }
}
