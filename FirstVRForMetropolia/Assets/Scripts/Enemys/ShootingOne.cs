using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingOne : MonoBehaviour
{
    [SerializeField] GameObject ammoPrefab;
    [SerializeField] Transform ammoSpawnPoint;
    [SerializeField] float bulletSpeed;
    

    public void Shoot(Vector3 targetDirection)
    {
        var bulletInstance = Instantiate(ammoPrefab, ammoSpawnPoint.position, Quaternion.identity);
        bulletInstance.GetComponent<Rigidbody>().AddForce(targetDirection * bulletSpeed * Time.deltaTime, ForceMode.Impulse);

        Destroy(bulletInstance, 5f);
    }

    
}
