using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRevealer : MonoBehaviour
{
    [SerializeField] GameObject[] enemys;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            for (int i = 0; i < enemys.Length; i++)
            {
                enemys[i].SetActive(true);
            }
            
        }
    }
}
