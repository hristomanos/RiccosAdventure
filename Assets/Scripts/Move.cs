using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [Range(0f,10f)]
    [SerializeField] int speed = 1;
    Rigidbody2D m_rigidBody2D;

    SpriteRenderer m_spriteRenderer;


    Animator m_Animator;


    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody2D = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        m_Animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");

        MoveCharacter(directionX);

        FlipSpriteX(directionX);

        m_Animator.SetFloat("Speed",Mathf.Abs(directionX));
            
        
    }




    void MoveCharacter(float directionX)
    {
        m_rigidBody2D.velocity = new Vector2(directionX * speed, m_rigidBody2D.velocity.y);
    }

    void FlipSpriteX(float directionX)
    {
        if (directionX < 0)
        {
            m_spriteRenderer.flipX = true;
        }

        if (directionX > 0)
        {
            m_spriteRenderer.flipX = false;
        }

    }

}
