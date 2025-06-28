using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Range(0f,10f)]
    [SerializeField] int speed = 1;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");

        MoveCharacter(directionX);

        FlipSpriteX(directionX);

        animator.SetFloat("Speed",Mathf.Abs(directionX));
    }
    
    void MoveCharacter(float directionX)
    {
        rb.velocity = new Vector2(directionX * speed, rb.velocity.y);
    }

    void FlipSpriteX(float directionX)
    {
        if (directionX < 0)
        {
            spriteRenderer.flipX = true;
        }

        if (directionX > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
