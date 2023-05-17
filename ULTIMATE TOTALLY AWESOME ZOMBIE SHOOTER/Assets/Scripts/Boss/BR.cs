using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRun : StateMachineBehaviour
{
   public float speed = 2f;

   public float shootRange; 
   GameObject boss; 

   float distance; 
   float timer; 

   Transform player;
   Rigidbody2D rb; 

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
      Vector2 target = new Vector2(player.position.x, rb.position.y);
      Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
      rb.MovePosition(newPos);

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
       animator.ResetTrigger("RunShoot");
   }

   
}

