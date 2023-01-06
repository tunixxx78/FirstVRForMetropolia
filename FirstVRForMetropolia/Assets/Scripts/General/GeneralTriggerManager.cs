using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralTriggerManager : MonoBehaviour
{
    [SerializeField] GameObject triggerAction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerAction.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
