using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 100;

    public int ammoAmount = 10;

    AmmoBarScript ammoBarScript;

    private void Awake()
    {
        ammoBarScript = FindObjectOfType<AmmoBarScript>();
    }

    private void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);

        ammoBarScript.SetMaxAmmo(ammoAmount);
    }

    public void FireBullet(ActivateEventArgs arg)
    {
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed * Time.deltaTime;
        Destroy(spawnedBullet, 5f);

        ammoAmount--;
        ammoBarScript.SetAmmo(ammoAmount);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Holster"))
        {
            transform.SetParent(collision.transform);
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
