using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    
    Transform point;
    int m_CurrentWaypointIndex;

    bool m_IsObserverCaught;
   
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
            {
                m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
                navMeshAgent.SetDestination (waypoints[m_CurrentWaypointIndex].position);
            }
        if(m_IsObserverCaught)
        {
            navMeshAgent.SetDestination(point.position);
        }
    }

    public void ObserverCaught(Transform gargoyle)
    {
        point = gargoyle;
        m_IsObserverCaught = true;
    }
}
