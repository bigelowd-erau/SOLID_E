using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRay : IRay
{
    public Vector3 direction { get; set; }
    public Vector3 origin { get; set; }
    private GameObject BallRayBall;
    private BallRayCaster caster;

    private float speed = 0.01f;
    private bool casting = false;
    public BallRay(Ray ray)
    {
        origin = ray.origin;
        direction = ray.direction;
        BallRayBall = GameObject.FindGameObjectWithTag("BallRay");
        caster = BallRayBall.GetComponent<BallRayCaster>();
    }
    public bool Cast(out GameObject hit)
    {
        BallRayBall.transform.position = origin;
        return caster.Cast(out hit, direction);
    }
    
}
