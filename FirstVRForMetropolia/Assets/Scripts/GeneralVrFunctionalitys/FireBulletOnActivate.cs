using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 1000, plrShootDelay;

    //public int ammoAmount = 10;

    AmmoBarScript ammoBarScript;
    SFXHOLDER sFXHOLDER;
    GunManager gunManager;

    bool canShoot;

    private void Awake()
    {
        ammoBarScript = FindObjectOfType<AmmoBarScript>();
        sFXHOLDER = FindObjectOfType<SFXHOLDER>();
        gunManager = FindObjectOfType<GunManager>();
        canShoot = true;
    }

    private void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);

        ammoBarScript.SetMaxAmmo(gunManager.ammoAmount);
    }

    public void FireBullet(ActivateEventArgs arg)
    {
        if (canShoot && gunManager.ammoAmount > 0)
        {
            canShoot = false;
            sFXHOLDER.blaster.Play();
            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = spawnPoint.position;

            Transform dir = spawnPoint;

            //spawnedBullet.GetComponent<PLRBullet>().ShootingBullets(dir);


            //spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed * Time.deltaTime;

            spawnedBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * fireSpeed * Time.deltaTime, ForceMode.Impulse);

            //bulletInstance.GetComponent<Rigidbody>().AddForce(targetDirection * bulletSpeed * Time.deltaTime, ForceMode.Impulse);
            Destroy(spawnedBullet, 5f);

            gunManager.ammoAmount--;
            ammoBarScript.SetAmmo(gunManager.ammoAmount);

            StartCoroutine(CanShootDelay());
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

    IEnumerator CanShootDelay()
    {
        yield return new WaitForSeconds(plrShootDelay);
        canShoot = true;
    }

   
    
}
