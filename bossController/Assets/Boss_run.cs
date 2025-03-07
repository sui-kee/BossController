using Unity.VisualScripting;
using UnityEngine;

public class Boss_run : StateMachineBehaviour
{
    Rigidbody2D rb;
    public float speed = 3f;
    Transform player;
    Onre onre;
    public float attackRange = 0.4f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        onre = animator.GetComponent<Onre>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector2.Distance(player.position, rb.position);
        if (distance < attackRange)
        {
            animator.SetTrigger("Attack");
        }
        if (onre.isHurt)
        {
            animator.SetTrigger("Hurt");
        }
        if (onre.isFacingRight && rb.position.x > player.position.x )
        {
            onre.OnreFlip();
        }
        else if (!onre.isFacingRight && rb.position.x < player.position.x )
        {
            onre.OnreFlip();
        }
        //Vector2 target = new Vector2(player.position.x, player.position.y); 
        //Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed*Time.fixedDeltaTime);
        //rb.MovePosition(newPos);
    
            float direction = onre.isFacingRight ? 1f : -1f;
            rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
        

    

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Hurt");
    }

}
