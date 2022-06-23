using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class MoveToClickPos : MonoBehaviour
{
    private NavMeshAgent agent;
    [Header("Player")]
    [Tooltip("Move speed of the character in m/s")]
    public float MoveSpeed = 2.0f;

    [Tooltip("Sprint speed of the character in m/s")]
    public float SprintSpeed = 5.335f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Mouse mouse = Mouse.current;
        if (mouse.leftButton.wasPressedThisFrame)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(mouse.position.ReadValue().x,mouse.position.ReadValue().y)),out hit,100))
            {
                agent.destination = hit.point;
                if ((agent.destination - transform.position).magnitude > 3f)
                {
                    agent.speed = SprintSpeed;
                }
                else agent.speed = MoveSpeed;
            }
        }
    }
}
