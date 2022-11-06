using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField] float treshold = 0.1f;
    [SerializeField] float deadZone = 0.025f;

    bool isPressed;
    Vector3 startPos;
    ConfigurableJoint joint;

    public UnityEvent onPressed, onReleased;

    private void Start()
    {
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    private void Update()
    {
        if(!isPressed && GetValue() + treshold >= 1)
        {
            Pressed();
        }
        if(isPressed && GetValue() - treshold <= 0)
        {
            Released();
        }
    }

    private float GetValue()
    {
        float value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;

        if(Mathf.Abs(value) < deadZone)
        {
            value = 0;
        }
        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        isPressed = true;
        onPressed.Invoke();
        Debug.Log("Pressed");
    }
    private void Released()
    {
        isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
    } 

}
