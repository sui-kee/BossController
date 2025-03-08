using System.Collections;
using UnityEngine;

public class Onre : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public bool isFacingRight = true;
    public bool isHurt = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetFloat("yVelocity", rb.linearVelocity.y);
        //if (rb.linearVelocity.y != 0)
        //{
        //    animator.SetBool("isFlying", true);
        //}
        //else if(rb.linearVelocity.y == 0)
        //{
        //    animator.SetBool("isFlying",false);
        //}
    }

    public IEnumerator OnreHurt()
    {
        isHurt=true;
        yield return new WaitForSeconds(0.20f);
        isHurt=false;
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
    }
    public void OnreFlip()
    {

        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fireball"))
        {
            StartCoroutine(OnreHurt());
        }
    }
}
