using UnityEngine;

public class CircleRayCastBasedTagSelector : MonoBehaviour, ISelector
{
    [SerializeField] private string selectableTag = "Selectable";
    private Transform _selection;
    private float radius = 0.5f;
    private int sampleSize = 100;
    public void Check(Ray ray)
    {
        this._selection = null;
        RaycastHit hit;
        for (int i = 0; i < sampleSize; ++i)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Collide))
            {
                var selection = hit.transform;
                if (selection.CompareTag(this.selectableTag))
                {
                    this._selection = selection.transform;
                }
            }
            //Formula to move ray around circular point
        }
    }
    public Transform GetSelection()
    {
        return this._selection;
    }
}