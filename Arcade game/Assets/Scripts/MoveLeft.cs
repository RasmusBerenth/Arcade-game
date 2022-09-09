using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    PlayerControlls playerControllsScript;
    private float speed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerControllsScript = GameObject.Find("Player").GetComponent<PlayerControlls>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Move game objects to the left until the game is over
        if (playerControllsScript.gameOver == false)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
    }
}
