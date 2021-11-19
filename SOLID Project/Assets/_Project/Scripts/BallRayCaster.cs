using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRayCaster : MonoBehaviour
{
    private float speed = .01f;
    bool hasCollided = false;
    GameObject collidedObj = null;
    public bool Cast(out GameObject hit, Vector3 direction)
    {
        hasCollided = false;
        collidedObj = null;
        for (int i = 0; i < 100000 && !hasCollided; ++i)
        {
            transform.position += direction * speed;
        }
        hit = collidedObj;
        return collidedObj != null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collidedObj = collision.collider.gameObject;
        hasCollided = true;
    }
}
