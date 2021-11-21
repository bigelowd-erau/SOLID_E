using System.Collections.Generic;
using UnityEngine;

public class ResponsiveSelector : MonoBehaviour, ISelector
{
    [SerializeField] private List<Selectable> selectables;
    private const float threshold = 0.99f;
    private Transform _selection;
    public void Check(Stack<Ray> rays)
    {
        Ray ray = rays.Pop();
        _selection = null;
        float closest = 0;
        for (int i = 0; i < selectables.Count; ++i)
        {
            var vector1 = ray.direction;
            var vector2 = selectables[i].transform.position - ray.origin;
            var lookPercentage = Vector3.Dot(vector1.normalized, vector2.normalized);

            selectables[i].LookPercentage = lookPercentage;
            if (lookPercentage > threshold && lookPercentage > closest)
            {
                closest = lookPercentage;
                _selection = selectables[i].transform;
            }
        }
    }

    public Transform GetSelection()
    {
        return _selection;
    }
}
