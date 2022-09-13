using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOnGround : MonoBehaviour
{
    public bool isOnGround;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
    }
}
