using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Switcher : MonoBehaviour
{
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
