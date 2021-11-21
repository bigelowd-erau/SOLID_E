using UnityEngine;
using System.Collections.Generic;

public class MouseScreenRayProvider : MonoBehaviour, IRayProvider
{
    public Stack<Ray> CreateRay()
    {
        Stack<Ray> ray = new Stack<Ray>();
       // Debug.Log("reg ray made");
        ray.Push(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)));
        return ray;
    }
}