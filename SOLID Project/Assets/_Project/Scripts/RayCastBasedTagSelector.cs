using UnityEngine;
using System.Collections.Generic;

public class RayCastBasedTagSelector : MonoBehaviour, ISelector
{
    [SerializeField] private string selectableTag = "Selectable";
    private Transform _selection;
    public void Check(Stack<Ray> rays)
    {
        Ray ray = rays.Pop();
        this._selection = null;
        if (Physics.Raycast(ray, out var hit, Mathf.Infinity, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Collide))
        {
            Debug.DrawRay(ray.origin, ray.direction * 5, Color.red, 2.0f);
            var selection = hit.transform;
            if (selection.CompareTag(this.selectableTag))
            {
                this._selection = selection.transform;
            }
        }
    }
    public Transform GetSelection()
    {
        return this._selection;
    }
}