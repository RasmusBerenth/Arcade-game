using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public bool isOnGround;
    public float jumpForce;
    public float highGravity;
    public float lowGravity;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isOnGround == true)
        {
            //playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            playerRb.velocity = Vector2.up * jumpForce;
            isOnGround = false;
        }

        // Going down faster than up during a jump
        //if (!Input.GetKey(KeyCode.Space) && isOnGround == false)
        //{
        //    playerRb.velocity = Vector2.down * jumpForce * 2;
        //}

        //Lower gravity when holding the up key in order to make the player glide
        if (Input.GetKey(KeyCode.UpArrow) && isOnGround == false)
        {
            playerRb.gravityScale = lowGravity;
        }
        //Raise the gravity in order to make the player fall faster
        else if (Input.GetKey(KeyCode.DownArrow) && isOnGround == false)
        {
            playerRb.gravityScale = highGravity;
        }
        else
        {
            playerRb.gravityScale = 5;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
    }
}
