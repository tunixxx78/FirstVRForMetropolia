using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BladeOnActivate : MonoBehaviour
{

    [SerializeField] GameObject lightSaber;
    bool isOn = false;
    SFXHOLDER sFXHOLDER;

    private void Awake()
    {
        sFXHOLDER = FindObjectOfType<SFXHOLDER>();
    }

    private void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(TurnBladeOn);

    }

    public void TurnBladeOn(ActivateEventArgs arg)
    {
        if(isOn == false)
        {
            sFXHOLDER.saberOn.Play();
            sFXHOLDER.saber.Play();
            lightSaber.SetActive(true);
            isOn = true;
        }
        else if(isOn)
        {
            sFXHOLDER.saberOff.Play();
            sFXHOLDER.saber.Stop();
            lightSaber.SetActive(false);
            isOn = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Holster"))
        {
            transform.SetParent(collision.transform);
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RightHand"))
        {
            Debug.Log("ase irtoaa holstrerista!!!");
            this.gameObject.transform.SetParent(GameObject.Find("GunHolder").transform);
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.gameObject.transform.localScale = new Vector3(4, 4, 4);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Holster"))
        {
            //transform.SetParent(collision.transform);
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }

   
    
}
