using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walk : StateMachineBehaviour
{
    float timer;
    List<Transform> Points = new List<Transform>();
    NavMeshAgent agent;
    Transform Player;
    float ChaseRange = 8;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 1.5f;
        timer = 0;
        Transform WayPointsObject = GameObject.FindGameObjectWithTag("WayPoints").transform;
        foreach (Transform t in WayPointsObject)

            Points.Add(t);

        agent.SetDestination(Points[0].position);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (agent.remainingDistance <= agent.stoppingDistance)

            agent.SetDestination(Points[Random.Range(0, Points.Count)].position);

        timer += Time.deltaTime;

        if (timer > 10)
            animator.SetBool("IsPatrolling", false);
        float distance = Vector3.Distance(Player.position, animator.transform.position);
        if (distance < ChaseRange)
            animator.SetBool("IsChasing", true);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}