using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector2 startPosition;
    private float repeatWith = -110;

    // Start is called before the first frame update
    void Start()
    {
        //Locating starting position for background
        startPosition = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Background is now on a loop
        if (transform.position.x < repeatWith)
        {
            transform.position = startPosition;
        }

    }
}
