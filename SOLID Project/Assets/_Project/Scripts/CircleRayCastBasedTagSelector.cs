using UnityEngine;
using System.Collections.Generic;

public class CircleRayCastBasedTagSelector : MonoBehaviour, ISelector
{
    [SerializeField] private string selectableTag = "Selectable";
    private Transform _selection;
    private Stack<Transform> selectables;
    private const int selectablesMaxSize = 4;
    public void Check(Stack<Ray> rays)
    {
        this._selection = null;
        RaycastHit hit;
        float closest = 0;

        while (rays.Count > 0)// foreach (Ray ray in rays)
        {
            Ray ray = rays.Pop();
            Debug.DrawRay(ray.origin, ray.direction * 6, Color.red, 2.0f);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Collide))
            {
                var selection = hit.transform;
                var lookPercentage = Vector3.Dot(ray.direction.normalized, (selection.transform.position - ray.origin).normalized);
                if (selection.CompareTag(this.selectableTag) && lookPercentage > closest)
                {
                    _selection = selection;
                    closest = lookPercentage;
                }
            }
        }
    }
    public Transform GetSelection()
    {
        return this._selection;
    }
}