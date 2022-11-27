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
    [SerializeField] int plantHealth, plantMaxHealth;
    HealthBarScript healthBarScript;

    private void Awake()
    {
        plantAnimator = GetComponent<Animator>();
        hasNoticed = false;
        healthBarScript = GetComponentInChildren<HealthBarScript>();
        plantMaxHealth = plantHealth;
    }

    private void Start()
    {
        healthBarScript.SetMaxValue(plantHealth);
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

        if(plantHealth <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Blade" || collision.collider.tag == "Bullet")
        {
            plantHealth--;
            healthBarScript.SetHealth(plantHealth);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blade"))
        {
            plantHealth--;
            healthBarScript.SetHealth(plantHealth);
        }
    }
}
