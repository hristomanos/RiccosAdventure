using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Collider2D colliderBox;

    [SerializeField] LayerMask groundLayerMask; 

    [Range(300,600)]
    [SerializeField] int jumpForce = 450;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        JumpCharacter();
    }

    void JumpCharacter()
    {
        if(Input.GetButtonDown("Jump") && IsAllowedToJump())
        {
            rb.AddForce(jumpForce * Vector2.up);
        }
    }

    bool IsAllowedToJump()
    {
        var rightBottom = new Vector2(transform.position.x + colliderBox.bounds.extents.x,
            transform.position.y - colliderBox.bounds.extents.y);

        var leftBottom = new Vector2(transform.position.x - colliderBox.bounds.extents.x,
            transform.position.y - colliderBox.bounds.extents.y);

        var centerBottom = new Vector2(transform.position.x,
            transform.position.y - colliderBox.bounds.extents.y);

        return CheckIfGroundIsHit(rightBottom) ||
            CheckIfGroundIsHit(leftBottom) ||
            CheckIfGroundIsHit(centerBottom);
    }

    private bool CheckIfGroundIsHit(Vector2 rayOriginPosition)
    {
        if ( Physics2D.Raycast(rayOriginPosition, Vector2.down, 0.1f, groundLayerMask) )
        {
            return true;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        var rightBottom = new Vector2(transform.position.x + colliderBox.bounds.extents.x,
            transform.position.y - colliderBox.bounds.extents.y);

        var leftBottom = new Vector2(transform.position.x - colliderBox.bounds.extents.x,
            transform.position.y - colliderBox.bounds.extents.y);

        var centerBottom = new Vector2(transform.position.x,
            transform.position.y - colliderBox.bounds.extents.y);

        var length = 0.1f;


        Gizmos.color = Color.red;
        
        Gizmos.DrawLine(rightBottom, new Vector2(rightBottom.x, rightBottom.y - length));
        Gizmos.DrawLine(leftBottom, new Vector2(leftBottom.x, leftBottom.y - length));
        Gizmos.DrawLine(centerBottom, new Vector2(centerBottom.x, centerBottom.y - length));
    }
}
