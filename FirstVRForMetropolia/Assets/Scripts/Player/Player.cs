using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    HealthBarScript healthBarScript;
    AmmoBarScript ammoBarScript;
    FireBulletOnActivate fireBulletOnActivate;

    [SerializeField] int plrHealth = 10;
    [SerializeField] int plrMaxHealth;

    private void Awake()
    {
        healthBarScript = GetComponentInChildren<HealthBarScript>();
        ammoBarScript = GetComponentInChildren<AmmoBarScript>();
        fireBulletOnActivate = FindObjectOfType<FireBulletOnActivate>();
        plrMaxHealth = plrHealth;
    }

    private void Start()
    {
        healthBarScript.SetMaxValue(plrHealth);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ammo"))
        {
            Debug.Log("Ammo osuu pelaajaan!");
            ammoBarScript.SetMaxAmmo(fireBulletOnActivate.ammoAmount + 5);
            fireBulletOnActivate.ammoAmount += 5;

            Destroy(other.gameObject, 1f);
        }
        if (other.CompareTag("Health"))
        {
            int healthCollectibleAmount = other.gameObject.GetComponent<HealthObject>().healthAmount;

            if(plrHealth <= (plrHealth + healthCollectibleAmount))
            {
                plrHealth = plrHealth + healthCollectibleAmount;
                healthBarScript.SetHealth(plrHealth);

                Destroy(other.gameObject, 1f);
            }
            else
            {
                plrHealth = plrMaxHealth;
                healthBarScript.SetHealth(plrHealth);

                Destroy(other.gameObject, 1f);
            }
        }
        if (other.CompareTag("HoldInDistance"))
        {
            plrHealth--;
            healthBarScript.SetHealth(plrHealth);
        }

        if (other.CompareTag("Enemy"))
        {
            plrHealth--;
            healthBarScript.SetHealth(plrHealth);
        }
        if (other.CompareTag("Elevator"))
        {
            transform.SetParent(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Elevator"))
        {
            transform.SetParent(GameObject.Find("PlayerHolder").transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            plrHealth--;
            healthBarScript.SetHealth(plrHealth);
        }
        if(collision.collider.tag == "Elevator")
        {
            transform.SetParent(collision.transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.tag == "Elevator")
        {
            transform.SetParent(GameObject.Find("PlayerHolder").transform); 
        }
    }
}
