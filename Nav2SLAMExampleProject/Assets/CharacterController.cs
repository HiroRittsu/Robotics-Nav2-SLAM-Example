using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterController : MonoBehaviour
{
    [SerializeField] private Transform[] Waypoints;
    private NavMeshAgent navMeshAgent;
    private int currentWaypointIndex;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(Waypoints[0].position);
    }

    private void Update()
    {
        if (!(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)) return;

        currentWaypointIndex = (currentWaypointIndex + 1) % Waypoints.Length;
        navMeshAgent.SetDestination(Waypoints[currentWaypointIndex].position);
    }
}