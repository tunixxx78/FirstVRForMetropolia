using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLRBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    Transform bulletDir;
    bool canShoot = false;

    private void Update()
    {
        if(canShoot == true)
        {
            //GetComponent<Rigidbody>().velocity = bulletDir.forward * bulletSpeed * Time.deltaTime;
            GetComponent<Rigidbody>().AddForce(bulletDir.forward * bulletSpeed * Time.deltaTime, ForceMode.Impulse);
        }
    }

    public void ShootingBullets(Transform dir)
    {
        bulletDir = dir;
        canShoot = true;
    }
}
