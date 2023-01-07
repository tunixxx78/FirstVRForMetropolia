using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    [SerializeField] string tagName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagName))
        {
            Destroy(gameObject, 5f);
        }
    }
}
