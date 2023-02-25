using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] AudioSource ship;


    public void ShipSound()
    {
        ship.Play();
    }
}
