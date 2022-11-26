using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    NavMeshAgent enemyAgent;
    public Transform targetPLR;
    [SerializeField] float noticeDistance, attackDistance, shootingDistance, enemySpeed;
    Vector3 position;
    [SerializeField] bool enemyOne, enemyTwo, enemyThree, canShoot, canWalk, canAttack;
    [SerializeField] float shootingDelay, shootingAnimationDelay;

    Animator enemyAnimator;
    [SerializeField] Animator enemyBaseAnimator;

    private void Awake()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        //enemyAnimator = GetComponentInChildren<Animator>();
        canAttack = true;
        canWalk = true;
    }

    private void Start()
    {
        position = this.transform.position;
        canShoot = true;
        enemyAgent.speed = 0;
    }

    private void Update()
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
}
