using UnityEngine;

public class Onre : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    public bool isFacingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetFloat("yVelocity", rb.linearVelocity.y);
        if (rb.linearVelocity.y != 0)
        {
            animator.SetBool("isFlying", true);
        }
        else if(rb.linearVelocity.y == 0)
        {
            animator.SetBool("isFlying",false);
        }
    }

    public void OnreFlip()
    {

        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
