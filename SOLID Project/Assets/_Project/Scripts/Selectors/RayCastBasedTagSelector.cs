using UnityEngine;
using System.Collections.Generic;

//Cast a ray and selects if that ray hits an obj with the selectable tag
public class RayCastBasedTagSelector : MonoBehaviour, ISelector
{
    [SerializeField] private string selectableTag = "Selectable";
    private Transform _selection;
    public void Check(Stack<Ray> rays)
    {
        //Get first ray in provided list
        //this selector only handles one ray
        Ray ray = rays.Pop();
        this._selection = null;
        //if raycast hit something
        if (Physics.Raycast(ray, out var hit, Mathf.Infinity, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Collide))
        {
            var selection = hit.transform;
            //if the hit obj has the selectableTag select the obj
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