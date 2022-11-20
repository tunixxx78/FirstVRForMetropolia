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
    [SerializeField] bool enemyOne, enemyTwo, enemyThree, canShoot;
    [SerializeField] float shootingDelay;

    Animator enemyAnimator;
    [SerializeField] Animator enemyBaseAnimator;

    private void Awake()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        position = this.transform.position;
        canShoot = true;
    }

    private void Update()
    {
        position = this.transform.position;

        if (Vector3.Distance(position, targetPLR.position) < noticeDistance)
        {
            enemyAgent.isStopped = false;
            enemyAgent.speed = enemySpeed;
            enemyAgent.SetDestination(targetPLR.position);
            enemyBaseAnimator.SetBool("EnemyWalk", true);

            if(Vector3.Distance(position, targetPLR.position) < attackDistance && enemyTwo)
            {
                enemyAnimator.SetTrigger("Attack");
                enemyBaseAnimator.SetTrigger("EnemyAttack");
                //enemyAgent.isStopped = true;
            }
            
        }
        if (Vector3.Distance(position, targetPLR.position) > noticeDistance)
        {
            Debug.Log("Enemyn olisi pitänyt pysähtyä");
            enemyAgent.isStopped = true;
            enemyAgent.speed = 0;
            enemyBaseAnimator.SetBool("EnemyWalk", false);
        }
        if (Vector3.Distance(position, targetPLR.position) < shootingDistance && enemyThree && canShoot)
        {
            Vector3 direction = targetPLR.position - position;
            GetComponent<ShootingOne>().Shoot(direction);

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
}
