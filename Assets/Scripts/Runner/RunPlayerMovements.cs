using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPlayerMovements : MonoBehaviour
{
    private float horizontal;
    private Rigidbody2D rb;
    public int vies;
    [SerializeField] private float speed;
    [SerializeField] private float invincibilityTime;
    [SerializeField] private RunnerController controller;
    private Transform tr;
    private SpriteRenderer spriteRenderer;
    private float invCooldown = 0;
    private float facing = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

        invCooldown += Time.deltaTime;

        rb.velocity = horizontal * speed * Vector2.right;
        if(invCooldown > 0)
        {
            spriteRenderer.color = Color.white;
        }

        if (horizontal > 0.1)
        {
            facing = 1f;
            tr.localScale = 0.4742059f * Vector3.one;
        }

        if (horizontal < -0.1)
        {
            facing = -1f;
            tr.localScale = new Vector3(-0.4742059f, 0.4742059f, 0.4742059f);
        }
    }

    public void GetInput()
    {
        horizontal = Input.GetAxis("Horizontal");
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        print("COLLISION");
        if (collision.gameObject.tag == "Caisse" && invCooldown > 0)
        {
            vies--;
            invCooldown = -invincibilityTime;
            controller.OnHit();
            spriteRenderer.color = Color.red;
        }
    }
}
