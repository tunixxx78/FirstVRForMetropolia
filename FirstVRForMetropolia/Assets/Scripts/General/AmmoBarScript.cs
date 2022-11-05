using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBarScript : MonoBehaviour
{
    public Slider ammoSlider;

    public void SetMaxAmmo(int ammo)
    {
        ammoSlider.maxValue = ammo;
        ammoSlider.value = ammo;
    }
    public void SetAmmo(int ammo)
    {
        ammoSlider.value = ammo;
    }
}
