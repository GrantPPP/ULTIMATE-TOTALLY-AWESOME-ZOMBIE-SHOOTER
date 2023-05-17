using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BS : StateMachineBehaviour
{
    float distance; 

    Transform player;
   Rigidbody2D rb; 

   GameObject boss; 

   float timer; 

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = GameObject.FindWithTag("Boss");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        distance = Vector2.Distance(player.position, rb.position);
        animator.SetFloat("Distance", distance, .1f, .1f);
        timer += Time.deltaTime; 

        if(timer >= 1)
        {
            boss.GetComponent<Boss_Shoot>().Shoot();
            timer = 0;
        }

        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

   
}
