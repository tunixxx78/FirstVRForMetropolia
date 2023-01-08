using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Drone_Base : MonoBehaviour
{
    NavMeshAgent droneAgent;
    [SerializeField] Transform targetPLR;
    [SerializeField] float noticeDistance, attackDistance;
    Vector3 position;

    private void Awake()
    {
        droneAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        position = this.transform.position;

        if (Vector3.Distance(position, targetPLR.position) < noticeDistance)
        {
            droneAgent.baseOffset = 3;
            droneAgent.SetDestination(targetPLR.position);
            
        }
    }
}
