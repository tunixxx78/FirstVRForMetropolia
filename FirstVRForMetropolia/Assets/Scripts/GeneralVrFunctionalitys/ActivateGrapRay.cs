using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateGrapRay : MonoBehaviour
{
    public GameObject leftGrapRay;
    public GameObject rightGrapRay;

    public XRDirectInteractor leftDirectGrap;
    public XRDirectInteractor rightDirectGrap;


    private void Update()
    {
        leftGrapRay.SetActive(leftDirectGrap.interactablesSelected.Count == 0);
        rightGrapRay.SetActive(rightDirectGrap.interactablesSelected.Count == 0);
    }
}
