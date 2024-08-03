using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : StateMachineBehaviour
{
    Transform Player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(Player);
        float distance = Vector3.Distance(Player.position, animator.transform.position);
        if (distance > 3.5f)
            animator.SetBool("IsAttacking", false);
    }
}