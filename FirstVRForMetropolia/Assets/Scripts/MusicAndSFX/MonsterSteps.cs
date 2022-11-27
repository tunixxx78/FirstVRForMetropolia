using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MonsterSteps : MonoBehaviour
{
    [SerializeField] AudioSource leftStep, rightStep;

    public void RightStep()
    {
        rightStep.Play();
    }

    public void LeftStep()
    {
        leftStep.Play();
    }
}
