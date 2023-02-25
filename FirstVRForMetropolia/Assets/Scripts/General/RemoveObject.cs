using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveObject : MonoBehaviour
{
    [SerializeField] Animator fakedoorAnimator;
    SFXHOLDER sFXHOLDER;

    private void Awake()
    {
        sFXHOLDER = FindObjectOfType<SFXHOLDER>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sFXHOLDER.openingWall.Play();
            fakedoorAnimator.SetTrigger("OpenFake");
        }
    }
}
