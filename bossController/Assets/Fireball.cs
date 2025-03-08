using System.Collections;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    Player player;
    [SerializeField] private Animator animator;
    public float arrowSpeed = 5f;
    public bool isReturn = false;// for arrow coming back or not
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (!player.rangeMode)
        {
            rb.linearVelocity = transform.right * arrowSpeed;
        }
        else
        {
            transform.localScale *= 1.7f;
            //Vector2 target = new Vector2(onre.position.x,onre.position.y);
            //Vector2 newPosition = Vector2.MoveTowards(rb.position,target,arrowSpeed*Time.deltaTime);
            //rb.MovePosition(newPosition);
            if (player.isFacingRight)
            {
                rb.linearVelocity = new Vector2(2, -1).normalized * arrowSpeed;

            }
            else
            { 
                rb.linearVelocity = new Vector2(-2, -1).normalized * arrowSpeed;
            
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator Explode()
    {
        rb.linearVelocity = new Vector2(0f, 0f);
        animator.CrossFade("FireBallExplode",0.1f);
        yield return new WaitForSeconds(0.20f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            StartCoroutine(Explode());
        }
    }
}
