using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRevealer : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.SetActive(true);
        }
    }
}
