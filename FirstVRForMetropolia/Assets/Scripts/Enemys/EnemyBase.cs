using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    NavMeshAgent enemyAgent;
    [SerializeField] Transform targetPLR;
    [SerializeField] float noticeDistance;
    Vector3 destination;

    private void Awake()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        destination = enemyAgent.destination;
    }

    private void Update()
    {
        destination = enemyAgent.destination;

        if (Vector3.Distance(destination, targetPLR.position) < noticeDistance)
        {
            enemyAgent.isStopped = false;
            enemyAgent.SetDestination(targetPLR.position);
        }
        if (Vector3.Distance(destination, targetPLR.position) > noticeDistance)
        {
            enemyAgent.isStopped = true;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Blade" || collision.collider.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blade"))
        {
            Destroy(this.gameObject);
        }
    }
}
