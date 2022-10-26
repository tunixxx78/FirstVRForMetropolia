using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateGrapRay : MonoBehaviour
{
    public GameObject leftGrapRay;
    public GameObject rightGrapRay;

    public GameObject rightGrapRayHold;

    public XRDirectInteractor leftDirectGrap;
    public XRDirectInteractor rightDirectGrap;

    public XRRayInteractor rightRayHoldGrap;


    private void Update()
    {
        leftGrapRay.SetActive(leftDirectGrap.interactablesSelected.Count == 0);
        rightGrapRay.SetActive(rightDirectGrap.interactablesSelected.Count == 0);

        rightGrapRayHold.SetActive(rightDirectGrap.interactablesSelected.Count == 0 || rightRayHoldGrap.interactablesSelected.Count == 0);
    }
}
