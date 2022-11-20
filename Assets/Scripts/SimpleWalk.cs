using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWalk : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody2D rigidBody;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput += 1;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            horizontalInput -= 1;
        }

        rigidBody.velocity = new Vector2(horizontalInput * speed, 0);
    }
}

