using System.Collections.Generic;
using UnityEngine;


public class CircleMouseScreenRayProvider : MonoBehaviour, IRayProvider
{
    private float curAngle = 0.0f;
    private int sampleSize = 100;
    private float dAngle;
    private float radius = 0.03f;

    private void Awake()
    {
        dAngle = 360 / sampleSize;
    }

    public Stack<Ray> CreateRay()
    {
        Stack<Ray> rays = new Stack<Ray>();
        for (int i = 0; i < sampleSize; ++i)
        {
            rays.Push(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0) + new Vector3(Mathf.Sin(curAngle), Mathf.Cos(curAngle), 0) * radius));
            curAngle += dAngle;
        }
        curAngle = 0;
        return rays;
    }
}