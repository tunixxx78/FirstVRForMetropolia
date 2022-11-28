using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyShootSFX : MonoBehaviour
{
    [SerializeField] AudioSource spellShot;

    public void SpellShotSound()
    {
        spellShot.Play();
    }
}


