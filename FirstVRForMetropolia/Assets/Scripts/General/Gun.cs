using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    GunManager gunManager;
    AmmoBarScript ammoBar;
    [SerializeField] int ammoToGive;
    bool hasGivenAmmo;

    private void Awake()
    {
        gunManager = FindObjectOfType<GunManager>();
        ammoBar = FindObjectOfType<AmmoBarScript>();
        hasGivenAmmo = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("RightHand") && hasGivenAmmo == false || other.CompareTag("LeftHand") && hasGivenAmmo == false)
        {
            hasGivenAmmo = true;
            gunManager.ammoAmount += ammoToGive;
            ammoBar.SetMaxAmmo(gunManager.ammoAmount += ammoToGive);
        }
    }


}
