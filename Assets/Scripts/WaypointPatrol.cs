using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public float normalSpeed = 1.5f;
    public float spottedMultiplier = 2.0f;
    int m_CurrentWaypointIndex;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
        navMeshAgent.speed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerLocation = GameObject.FindWithTag("Player").transform.forward;
        Vector3 ghostLocation = GameObject.FindWithTag("Ghost").transform.forward;
        if (Vector3.Dot(ghostLocation, playerLocation) > 0.8f)
        {
            navMeshAgent.speed = (normalSpeed * spottedMultiplier);
        }
        else
        {
            navMeshAgent.speed = normalSpeed;
        }

        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }

        
    }
}
