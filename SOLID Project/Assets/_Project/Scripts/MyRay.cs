using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRay : IRay
{
    public Vector3 direction { get; set; }
    public Vector3 origin { get; set; }

    public MyRay(Vector3 _origin, Vector3 _direction)
    {
        origin = _origin;
        direction = _direction;
    }
    public MyRay(Ray ray)
    {
        origin = ray.origin;
        direction = ray.direction;
    }
    public bool Cast(out GameObject hit)
    {
        bool res = Physics.Raycast(origin, direction, out RaycastHit hitr, Mathf.Infinity, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Collide);
        hit = hitr.transform.gameObject;
        return res;
    }
}
