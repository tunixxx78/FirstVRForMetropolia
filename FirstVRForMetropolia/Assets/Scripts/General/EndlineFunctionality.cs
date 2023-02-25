using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EndlineFunctionality : MonoBehaviour
{
    [SerializeField] GameObject endgamePanel;
    [SerializeField] GameObject rightHand, lefthand;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endgamePanel.SetActive(true);
            rightHand.GetComponent<XRRayInteractor>().maxRaycastDistance = 30;
            lefthand.GetComponent<XRRayInteractor>().maxRaycastDistance = 30;
        }
    }
}
