using UnityEngine;
using System.Collections.Generic;

//Cast the list of rays and selects if that ray hits an obj with the selectable tag and if
//obj is closest to the look percentage for that list
//this version combines both responsive selector and ray cast selector
public class MultiRayCastBasedTagSelector : MonoBehaviour, ISelector
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
            //if the ray hits something
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Collide))
            {
                var selection = hit.transform;
                //calc its look percentage
                var lookPercentage = Vector3.Dot(ray.direction.normalized, (selection.transform.position - ray.origin).normalized);
                //if has the tag and is closer than any other hit obj this cycle select hit obj
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