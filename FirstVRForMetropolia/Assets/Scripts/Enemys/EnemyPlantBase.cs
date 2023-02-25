using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyPlantBase : MonoBehaviour
{
    [SerializeField] float noticeDistance, attackDistance, attackSounDelayAmount;
    [SerializeField] Transform plr;
    Animator plantAnimator;
    Vector3 position;
    bool hasNoticed, canPlayAttackSound;
    [SerializeField] int plantHealth, plantMaxHealth;
    HealthBarScript healthBarScript;

    [SerializeField] AudioSource plantIdle, plantAttack;

    private void Awake()
    {
        plantAnimator = GetComponent<Animator>();
        hasNoticed = false;
        canPlayAttackSound = true;
        healthBarScript = GetComponentInChildren<HealthBarScript>();
        plantMaxHealth = plantHealth;
        plantIdle.Play();
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
        if(Vector3.Distance(position, plr.position) <= attackDistance && canPlayAttackSound == true)
        {
            canPlayAttackSound = false;
            hasNoticed = true;
            plantAnimator.SetTrigger("Bite");
            plantAttack.Play();
            

            StartCoroutine(attackSoundDelay());
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
    IEnumerator attackSoundDelay()
    {
        yield return new WaitForSeconds(attackSounDelayAmount);
        canPlayAttackSound = true;
    }
}
