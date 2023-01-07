using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneManager : MonoBehaviour
{
    [SerializeField] Animator shipOne;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shipOne.SetTrigger("Run");
        }
    }

}
