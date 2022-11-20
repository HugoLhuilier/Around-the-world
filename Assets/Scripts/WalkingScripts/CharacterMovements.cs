using UnityEngine;
using System.Collections.Generic;

public class CharacterMovements : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer spriteRendererHead;

    private float horizontalAxis;
    public float facing = 1;
    public bool canMove = true;
    private float horizontalSpeed;
    private bool initialFlip;

    [SerializeField] private Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    [SerializeField] private float velPower;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRendererHead = transform.GetChild(0).GetComponent<SpriteRenderer>();
        initialFlip = GetComponent<SpriteRenderer>().flipX;
    }

    void Update()
    {
        getInput();
    }

    void FixedUpdate()
    {
        if (horizontalAxis > 0.1f)
        {
            facing = 1;
        }
        if (horizontalAxis < -0.1f)
        {
            facing = -1;
        }

        if (canMove)
        {
            horizontalSpeed = Run();
        }
        animator.SetFloat("Speed", Mathf.Abs(horizontalSpeed));
        animator.SetFloat("Facing", facing);
    }

    private void getInput() {
        horizontalAxis = Input.GetAxisRaw("Horizontal");
    }

    private float Run() {
        float targetSpeed = horizontalAxis * speed;
        float speedDif = targetSpeed - body.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.1f) ? acceleration : deceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
        body.AddForce(movement * Vector2.right);
        return movement;
    }

    private void Flip(float facing)
    {
        if(facing == -1)
        {
            spriteRenderer.flipX = !initialFlip;
            spriteRendererHead.flipX = !initialFlip;

        }
        else if (facing == 1)
        {
            spriteRenderer.flipX = initialFlip;
            spriteRendererHead.flipX = initialFlip;
        }
    }
}