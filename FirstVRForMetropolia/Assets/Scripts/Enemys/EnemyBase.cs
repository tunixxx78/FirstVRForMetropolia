using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    NavMeshAgent enemyAgent;
    public Transform targetPLR;
    [SerializeField] float noticeDistance, attackDistance, shootingDistance, enemySpeed, onHitDelay;
    Vector3 position;
    [SerializeField] bool enemyOne, enemyTwo, enemyThree, canShoot, canWalk, canAttack, canFunctions, canBeHit;
    [SerializeField] float shootingDelay, shootingAnimationDelay;

    Animator enemyAnimator;
    [SerializeField] Animator enemyBaseAnimator;

    [SerializeField] int enemyHealth, enemyMaxHealth;
    HealthBarScript enemyHealthBarScript;

    private void Awake()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyHealthBarScript = GetComponentInChildren<HealthBarScript>();
        enemyMaxHealth = enemyHealth;
        //enemyAnimator = GetComponentInChildren<Animator>();
        canAttack = true;
        canWalk = true;
        canFunctions = true;
        canBeHit = true;
    }

    private void Start()
    {
        position = this.transform.position;
        canShoot = true;
        enemyAgent.speed = 0;
        enemyHealthBarScript.SetMaxValue(enemyHealth);
    }

    private void Update()
    {
        if (canFunctions)
        {
            position = this.transform.position;

            if (Vector3.Distance(position, targetPLR.position) < noticeDistance && canWalk)
            {

                enemyAgent.isStopped = false;
                enemyAgent.speed = enemySpeed;
                enemyAgent.SetDestination(targetPLR.position);
                enemyBaseAnimator.SetBool("EnemyWalk", true);



            }
            if (Vector3.Distance(position, targetPLR.position) < attackDistance && enemyTwo && canAttack)
            {
                canWalk = false;
                //enemyAnimator.SetTrigger("EnemyAttack");
                enemyBaseAnimator.SetTrigger("EnemyAttack");
                enemyAgent.speed = 0.1f;
                //enemyAgent.isStopped = true;
                enemyBaseAnimator.SetBool("EnemyWalk", false);
            }

            if (Vector3.Distance(position, targetPLR.position) > noticeDistance)
            {
                canWalk = true;
                //Debug.Log("Enemyn olisi pitänyt pysähtyä");
                //enemyAgent.isStopped = true;
                enemyAgent.speed = 0;
                enemyBaseAnimator.SetBool("EnemyWalk", false);
            }
            if (Vector3.Distance(position, targetPLR.position) > attackDistance)
            {
                canWalk = true;
                enemyAgent.speed = enemySpeed;
                enemyBaseAnimator.SetBool("EnemyWalk", true);
            }

            if (Vector3.Distance(position, targetPLR.position) < shootingDistance && enemyThree && canShoot)
            {
                enemyBaseAnimator.SetTrigger("EnemyShoot");
                StartCoroutine(ShootNow());

                StartCoroutine(DelayOfShooting());
            }

            if (enemyHealth <= 0)
            {
                enemyBaseAnimator.SetTrigger("EnemyDie");
                enemyAgent.isStopped = true;
                if (enemyOne || enemyThree)
                {
                    Destroy(this.gameObject, 1.5f);
                }
                if (enemyTwo)
                {
                    Destroy(this.gameObject, 5f);
                }

            }
        }
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (canBeHit)
        {
            if (collision.collider.tag == "Blade" || collision.collider.tag == "Bullet")
            {
                canBeHit = false;
                enemyHealth--;
                enemyHealthBarScript.SetHealth(enemyHealth);
                canFunctions = false;
                StartCoroutine(HitDelay());
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (canBeHit)
        {
            if (other.CompareTag("Blade"))
            {
                canBeHit = false;
                enemyHealth--;
                enemyHealthBarScript.SetHealth(enemyHealth);
                canFunctions = false;
                StartCoroutine(HitDelay());
            }
        }
        
    }

    IEnumerator DelayOfShooting()
    {
        canShoot = false;

        yield return new WaitForSeconds(shootingDelay);

        canShoot = true;

    }
    IEnumerator ShootNow()
    {
        yield return new WaitForSeconds(shootingAnimationDelay);

        Vector3 direction = targetPLR.position - position;
        GetComponent<ShootingOne>().Shoot(direction);
    }

    IEnumerator HitDelay()
    {
        yield return new WaitForSeconds(onHitDelay);
        canFunctions = true; ;
        canBeHit = true;
    }
}
