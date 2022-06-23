using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class LocomotionSimpleAgent : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent agent;
    private float _speed;
    private float _animationBlend;
    [Header("Player")]
    [Tooltip("Move speed of the character in m/s")]
    public float MoveSpeed = 2.0f;

    [Tooltip("Sprint speed of the character in m/s")]
    public float SprintSpeed = 5.335f;
    [Tooltip("Acceleration and deceleration")]
    public float SpeedChangeRate = 10.0f;

    private Vector2 smoothDeltaPosition = Vector2.zero;
    private Vector2 velocity = Vector2.zero;

    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int MotionSpeed = Animator.StringToHash("MotionSpeed");

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float targetSpeed = pathComplete() ? 0f : agent.speed;

        Vector3 worldDeltaPosition = agent.nextPosition - transform.position;
        float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dx, dy);

        //smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition,deltaPosition,smooth);
        if (Time.deltaTime > 1e-5f) velocity = smoothDeltaPosition / Time.deltaTime;
        
        _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * SpeedChangeRate);
        if (_animationBlend < 0.01f) _animationBlend = 0f;

        anim.SetFloat(Speed,_animationBlend);
        anim.SetFloat(MotionSpeed,1);
        
        //GetComponent<LookAt>().lookAtTargetPosition = agent.steeringTarget + transform.forward;
        
    }
    
    protected bool pathComplete()
    {
        if ( Vector3.Distance( agent.destination, agent.transform.position) <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
            {
                return true;
            }
        }
 
        return false;
    }
}
