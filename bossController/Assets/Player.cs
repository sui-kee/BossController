using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public bool isAttacking = false;
    public bool isHurt = false;
    public float run_speed = 4f;
    public float jump_power = 5f;
    public float horizontal;
    public bool isFacingRight = true;
    public string comingAnimation = "";
    public string currentAnimation = "Idle";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump_power);
        }
        rb.linearVelocity = new Vector2(horizontal * run_speed, rb.linearVelocity.y);
        Flip();
        PlayerAnimatorController();// for controlling player animation
        PlayerMovementDetector();// for changing basic player animation run,idle,jump
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            //Vector3 localScale = transform.localScale;
            //localScale.x *= -1f;
            //transform.localScale = localScale;
            transform.Rotate(0f, 180f, 0f);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
    }

    public void PlayerMovementDetector()
    {
        if (horizontal != 0 && !isAttacking && IsGrounded() && !isHurt)
        {
            comingAnimation = "PlayerRun";
        }
        if (horizontal == 0 && !isAttacking && IsGrounded() && !isHurt)
        {
            comingAnimation = "PlayerIdle";
        }
        if (!isAttacking && !IsGrounded() && rb.linearVelocity.y > 0 && !isHurt)
        {
            comingAnimation = "PlayerJump";
        }
        if (!isAttacking && !IsGrounded() && rb.linearVelocity.y < 0 && !isHurt)
        {
            comingAnimation = "PlayerFall";
        }
    }
    public void ChangeAnimation(string animation, float crossFade = 0.2f)
    {
        if (currentAnimation != animation)
        {
            currentAnimation = animation;
            animator.CrossFade(animation, crossFade);
        }
    }

    private void PlayerAnimatorController()
    {
        switch (comingAnimation)
        {
            case "PlayerJump":

                ChangeAnimation("PlayerJump", 0.2f);
                break;
            case "PlayerFall":

                ChangeAnimation("PlayerFall", 0.2f);
                break;
            case "PlayerRun":

                ChangeAnimation("PlayerRun", 0.2f);
                break;
            case "PlayerIdle":
                ChangeAnimation("PlayerIdle", 0.2f);
                break;

        }
    }
}
