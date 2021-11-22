using UnityEngine;

internal class OutlineSelectionResponse : MonoBehaviour, ISelectionResponse
{
    public void OnSelect(Transform selection)
    {
        SetOutlineWidth(selection, 10);
    }
    public void OnDeselect(Transform selection)
    {
        SetOutlineWidth(selection, 0);
    }
    private void SetOutlineWidth(Transform selection, int width)
    {
        var outline = selection.GetComponent<Outline>();
        if (outline != null) outline.OutlineWidth =width;
    }
}
