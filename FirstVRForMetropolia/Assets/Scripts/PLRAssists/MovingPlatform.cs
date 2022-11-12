using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform  targetPosition;
    [SerializeField] float ObjectSpeed;
    [SerializeField] GameObject plr, plrHolder;
    Rigidbody platformRB;
    bool canMove = false;

    private void Awake()
    {
        platformRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (canMove)
        {
            //platformRB.AddForce(targetPosition.forward * ObjectSpeed * Time.deltaTime, ForceMode.VelocityChange);
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, targetPosition.position, ObjectSpeed * Time.deltaTime);
            plr.transform.position = Vector3.MoveTowards(plr.transform.position, targetPosition.position, ObjectSpeed * Time.deltaTime);
        }
    }

    public void MovePlatform()
    {
        canMove = true;
        //plr.transform.SetParent(this.gameObject.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Stopper"))
        {
            Debug.Log("LIIKKEEN OLISI PITÄNYT LOPPUA");
            canMove = false;
            //plr.transform.SetParent(plrHolder.transform);
        }
    }
    
}
