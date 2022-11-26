using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlantBase : MonoBehaviour
{
    [SerializeField] float noticeDistance, attackDistance;
    [SerializeField] Transform plr;
    Animator plantAnimator;
    Vector3 position;
    bool hasNoticed;

    private void Awake()
    {
        plantAnimator = GetComponent<Animator>();
        hasNoticed = false;
    }

    private void Update()
    {
        position = this.transform.position;
        if(Vector3.Distance(position, plr.position) <= noticeDistance && hasNoticed == false)
        {
            plantAnimator.SetTrigger("Threat");
        }
        if(Vector3.Distance(position, plr.position) <= attackDistance)
        {
            hasNoticed = true;
            plantAnimator.SetTrigger("Bite");
        }
        if (Vector3.Distance(position, plr.position) > attackDistance)
        {
            hasNoticed = false;
            
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
