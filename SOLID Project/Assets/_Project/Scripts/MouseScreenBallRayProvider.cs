using UnityEngine;

public class MouseScreenBallRayProvider : MonoBehaviour, IRayProvider
{
    public Ray CreateRay()
    {
        return Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        //return new BallRay(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)));
    }
}