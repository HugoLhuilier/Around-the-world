using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    private Rigidbody2D body;
    private BoxCollider2D bCollider;
    private Transform trans;

    private float horizontalAxis;
    public float facing = 1;

    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    [SerializeField] private float velPower;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        bCollider = GetComponent<BoxCollider2D>();
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }

    void FixedUpdate() {
        if (horizontalAxis > 0.1f)
        {
            facing = 1;
        }
        if (horizontalAxis < -0.1f)
        {
            facing = -1;
        }

        Run();
    }

    private void getInput() {
        horizontalAxis = Input.GetAxisRaw("Horizontal");
    }

    private void Run() {
        float targetSpeed = horizontalAxis * speed;
        float speedDif = targetSpeed - body.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.1f) ? acceleration : deceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
        body.AddForce(movement * Vector2.right);
    }
}