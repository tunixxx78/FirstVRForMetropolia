using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class Drone_Base : MonoBehaviour
{
    NavMeshAgent droneAgent;
    [SerializeField] Transform targetPLR;
    [SerializeField] float noticeDistance, attackDistance;
    [SerializeField] GameObject destructionParticle;
    Vector3 position;

    [SerializeField] AudioSource droneIdle, droneDestruction;

    private void Awake()
    {
        droneAgent = GetComponent<NavMeshAgent>();
        droneIdle.Play();
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Bullet")
        {

            droneDestruction.Play();
            destructionParticle.SetActive(true);
            Destroy(this.gameObject, 0.4f);
        }
    }
}
