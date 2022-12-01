using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveElevator : MonoBehaviour
{
    [SerializeField] GameObject doorToClose;
    SFXHOLDER sFXHOLDER;
    [SerializeField] float delay;

    private void Awake()
    {
        sFXHOLDER = FindObjectOfType<SFXHOLDER>();
        
    }

    public void MoveThisElevator()
    {
        sFXHOLDER.door.Play();
        doorToClose.GetComponent<Animator>().SetTrigger("DoorClose");
        StartCoroutine(CloseDoorNow());
    }

    IEnumerator CloseDoorNow()
    {
        yield return new WaitForSeconds(delay);
        GetComponent<Animator>().SetTrigger("ElevatorMove");
    }
}
