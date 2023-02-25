using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    HealthBarScript healthBarScript;
    AmmoBarScript ammoBarScript;
    FireBulletOnActivate fireBulletOnActivate;

    [SerializeField] int plrHealth = 10;
    [SerializeField] int plrMaxHealth;

    [SerializeField] GameObject deathParticle;
    [SerializeField] float deathDelay;

    GunManager gunManager;
    VoiceoverHolder voiceover;

    private void Awake()
    {
        gunManager = GetComponent<GunManager>();
        healthBarScript = GetComponentInChildren<HealthBarScript>();
        ammoBarScript = GetComponentInChildren<AmmoBarScript>();
        fireBulletOnActivate = FindObjectOfType<FireBulletOnActivate>();
        plrMaxHealth = plrHealth;

        voiceover = FindObjectOfType<VoiceoverHolder>();
    }

    private void Start()
    {
        healthBarScript.SetMaxValue(plrHealth);
    }

    private void Update()
    {
        if(plrHealth <= 0)
        {
            deathParticle.SetActive(true);
            StartCoroutine(KillPLR(deathDelay));
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ammo"))
        {
            Debug.Log("Ammo osuu pelaajaan!");
            ammoBarScript.SetMaxAmmo(gunManager.ammoAmount + 5);
            gunManager.ammoAmount += 5;

            Destroy(other.gameObject, 1f);
        }
        if (other.CompareTag("Health"))
        {
            int healthCollectibleAmount = other.gameObject.GetComponent<HealthObject>().healthAmount;

            if(plrHealth + healthCollectibleAmount <= plrMaxHealth)
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
            //transform.SetParent(other.transform);
            GameObject elev = GameObject.Find("Hissi");
            this.gameObject.transform.SetParent(elev.transform);
        }
        if (other.CompareTag("ElevatorTwo"))
        {
            //transform.SetParent(other.transform);
            GameObject elev = GameObject.Find("HissiTwo");
            this.gameObject.transform.SetParent(elev.transform);
        }
        if (other.CompareTag("ExitRoom"))
        {
            voiceover.wayBack.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Elevator"))
        {
            //transform.SetParent(GameObject.Find("PlayerHolder").transform);
            GameObject plrHold = GameObject.Find("PlayerHolder");
            this.gameObject.transform.SetParent(plrHold.transform);
        }
        if (other.CompareTag("ElevatorTwo"))
        {
            //transform.SetParent(GameObject.Find("PlayerHolder").transform);
            GameObject plrHold = GameObject.Find("PlayerHolder");
            this.gameObject.transform.SetParent(plrHold.transform);
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

    IEnumerator KillPLR(float delayTime)
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(currentScene);
    }

}
