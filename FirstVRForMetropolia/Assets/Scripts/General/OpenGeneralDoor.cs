using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGeneralDoor : MonoBehaviour
{
    [SerializeField] GameObject doorToOpen;
    SFXHOLDER sFXHOLDER;

    private void Awake()
    {
        sFXHOLDER = FindObjectOfType<SFXHOLDER>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sFXHOLDER.door.Play();
            doorToOpen.GetComponent<Animator>().SetTrigger("DoorOpen");
        }
    }
}
