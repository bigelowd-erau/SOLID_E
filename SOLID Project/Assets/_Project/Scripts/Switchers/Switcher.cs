using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enables switching to next of a changeable type
public abstract class Switcher : MonoBehaviour
{
    //both are provided by the concrete child implementation
    internal IChangeable changeableObject;
    internal KeyCode nextKeyCode;

    private void Update()
    {
        if (Input.GetKeyDown(nextKeyCode))
        {
            changeableObject.Next();
        }
    }
}
