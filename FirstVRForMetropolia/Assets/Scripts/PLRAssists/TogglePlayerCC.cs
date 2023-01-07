using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlayerCC : MonoBehaviour
{
    [SerializeField] GameObject plr;


    public void CCOff()
    {
        plr.GetComponent<BoxCollider>().isTrigger = false;
        plr.GetComponent<CharacterController>().enabled = false;
    }

    public void CCOn()
    {
        plr.GetComponent<BoxCollider>().isTrigger = true;
        plr.GetComponent<CharacterController>().enabled = true;
    }
}
