using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Player : Character
{
    private NavMeshAgent agent;
    [Header("Player")]
    [Tooltip("Move speed of the character in m/s")]
    public float MoveSpeed = 2.0f;

    [Tooltip("Sprint speed of the character in m/s")]
    public float SprintSpeed = 5.335f;

    public Interactable interaction;


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
                Vector3 destination = hit.point;
                destination = new Vector3(Mathf.Round(destination.x), destination.y, Mathf.Round(destination.z));
                agent.destination = destination;
                if ((agent.destination - transform.position).magnitude > 3f)
                {
                    agent.speed = SprintSpeed;
                }
                else agent.speed = MoveSpeed;
                if (hit.collider.gameObject.GetComponent<Interactable>() is Interactable i)
                {
                    StartCoroutine(AddInteraction(i));
                }
            }
        }
    }

    private IEnumerator AddInteraction(Interactable interactable)
    {
        Debug.Log("Add Interaction");
        if (interaction != null)
        {
            interaction.GetComponent<Interactable>().Select = false;
        }
        interactable.Select = true;
        interaction = interactable;
        yield return new WaitUntil(() => ReachedDest());
        interactable.Select = false;
        interactable.Interact(gameObject);        
    }

    public bool ReachedDest()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool ReachedDest(Vector3 dest)
    {
        if (!agent.pathPending)
        {
            if ((dest - transform.position).magnitude <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public override void TakeTurn(Combat combat)
    {
        throw new System.NotImplementedException();
    }
}
