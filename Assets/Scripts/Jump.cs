using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Visual")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("Physics")]
    [SerializeField] private Collider2D colliderBox;
    [SerializeField] private LayerMask groundLayerMask; 

    [Range(300,600)]
    [SerializeField] private int jumpForce = 450;

    private Rigidbody2D rb2D;
    private Animator animator;

    private bool jumpButtonPressed;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        JumpCharacter();
    }

    private void JumpCharacter()
    {
        if(Input.GetButtonDown("Jump") && IsAllowedToJump())
        {
            jumpButtonPressed = true;
        }
    }

    private void FixedUpdate()
    {
        if (jumpButtonPressed)
        {
            rb2D.AddForce(jumpForce * Vector2.up);
            ResetLandingAnimationFlag();
            jumpButtonPressed = false;
        }

        animator.SetFloat("VelocityY", rb2D.velocity.y);

        if(IsAllowedToJump() && rb2D.velocity.y < 0)
        {
            PlayLandingAnimation();
        }
    }

    private bool IsAllowedToJump()
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
        if(Physics2D.Raycast(rayOriginPosition, Vector2.down, 0.1f, groundLayerMask))
        {
            return true;
        }

        return false;
    }

    private void PlayLandingAnimation()
    {
        SetIsOnGroundAnimatorFlag(true);
    }

    private void ResetLandingAnimationFlag()
    {
        SetIsOnGroundAnimatorFlag(false);
    }

    private void SetIsOnGroundAnimatorFlag(bool isOnGround)
    {
        animator.SetBool("IsOnGround", isOnGround);
    }
}
