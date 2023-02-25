using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VoiceoverHolder : MonoBehaviour
{
    public AudioSource happening, noise, computer, off, sleep, where, home, wayBack;

    public void Happening()
    {
        happening.Play();
    }
    public void Noise()
    {
        noise.Play();
    }
    public void Computer()
    {
        computer.Play();
    }
    public void Off()
    {
        off.Play();
    }
    public void Sleep()
    {
        sleep.Play();
    }
}
