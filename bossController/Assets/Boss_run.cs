using UnityEngine;

public class Boss_run : StateMachineBehaviour
{
    Rigidbody2D rb;
    public float speed = 3f;
    Transform player;
    Onre onre;
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
        if (onre.isFacingRight && rb.position.x > player.position.x )
        {
            onre.OnreFlip();
        }
        else if (!onre.isFacingRight && rb.position.x < player.position.x )
        {
            onre.OnreFlip();
        }
        Vector2 target = new Vector2(player.position.x, player.position.y); 
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed*Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
