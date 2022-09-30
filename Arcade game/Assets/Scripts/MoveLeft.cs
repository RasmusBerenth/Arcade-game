using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    PlayerControlls playerControllsScript;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        playerControllsScript = GameObject.Find("Player").GetComponent<PlayerControlls>();
        if (CompareTag("Enemy"))
        {
            speed = 60;
        }
        else if (CompareTag("Background"))
        {
            speed = 5;
        }
        else
        {
            speed = 18;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move game objects to the left until the game is over
        if (playerControllsScript.gameOver == false)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
    }
}
