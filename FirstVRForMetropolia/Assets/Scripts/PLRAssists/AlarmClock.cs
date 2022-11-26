using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClock : MonoBehaviour
{
    [SerializeField] GameObject doorToOpen;
    SFXHOLDER sFXHOLDER;
    bool canCrap;

    private void Awake()
    {
        sFXHOLDER = FindObjectOfType<SFXHOLDER>();
    }

    private void Start()
    {
        sFXHOLDER.alarmClock.Play();
        canCrap = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeftHand") || other.CompareTag("RightHand"))
        {
            if (canCrap)
            {
                sFXHOLDER.alarmClock.Stop();
                doorToOpen.GetComponent<Animator>().SetTrigger("DoorOpen");
                sFXHOLDER.openingWall.Play();

                canCrap = false;
            }
            
        }
    }
}
