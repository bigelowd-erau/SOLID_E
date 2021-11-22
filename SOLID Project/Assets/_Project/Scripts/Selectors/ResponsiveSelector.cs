using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//Selects based on hor directly the vieport is facing the center of the object
public class ResponsiveSelector : MonoBehaviour, ISelector
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private List<GameObject> selectables;
    private const float threshold = 0.98f;
    private Transform _selection;

    private void Awake()
    {
        selectables = GameObject.FindGameObjectsWithTag(this.selectableTag).ToList();
    }

    public void Check(Stack<Ray> rays)
    {
        Ray ray = rays.Pop();
        _selection = null;
        float closest = 0;
        //loop through all selectables in the scene
        foreach (GameObject selectable in selectables)
        {
            var vector1 = ray.direction;
            var vector2 = selectable.transform.position - ray.origin;
            //Calculate the percentage the viewport is looking at the selectable
            var lookPercentage = Vector3.Dot(vector1.normalized, vector2.normalized);
            //if lookpercentage is above threshold and higher than closest make this obj the closest
            if (lookPercentage > threshold && lookPercentage > closest)
            {
                closest = lookPercentage;
                _selection = selectable.transform;
            }
        }
    }

    public Transform GetSelection()
    {
        return _selection;
    }
}
