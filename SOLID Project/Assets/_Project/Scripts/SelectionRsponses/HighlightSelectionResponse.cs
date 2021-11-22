using UnityEngine;

internal class HighlightSelectionResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField] public Material highlightMaterial;
    [SerializeField] public Material defaultMaterial;

    public void OnSelect(Transform selection)
    {
        SetMaterial(selection, true);
    }
    public void OnDeselect(Transform selection)
    {
        SetMaterial(selection, false);
    }
    //Sets the material of the selected object based on whether it is being selected or deselected
    private void SetMaterial(Transform selection, bool selected)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material = selected ? this.highlightMaterial : this.defaultMaterial;
        }
    }
}