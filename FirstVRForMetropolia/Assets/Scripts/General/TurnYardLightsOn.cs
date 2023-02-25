using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnYardLightsOn : MonoBehaviour
{
    [SerializeField] GameObject yardlights;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            yardlights.SetActive(true);
        }
    }
}
