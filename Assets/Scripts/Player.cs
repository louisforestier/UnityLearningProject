using System;
using UnityEngine;
using UnityEngine.AI;

class Player : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject interaction;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

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
}