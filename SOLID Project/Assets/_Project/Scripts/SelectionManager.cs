using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private ISelectionResponse _selectionResponse;
    private IRayProvider _rayProvider;
    private ISelector _selector;
    private Transform _currentSelection;

    private void Awake()
    {
        _selectionResponse = GetComponent<ISelectionResponse>();
        _rayProvider = GetComponent<IRayProvider>();
        _selector = GetComponent<ISelector>();
    }

    private void Update()
    {
        if (_currentSelection != null) _selectionResponse.OnDeselect(_currentSelection);

        Ray ray = _rayProvider.CreateRay();

        //Selection Determination
        _selector.Check(ray);

        _currentSelection = _selector.GetSelection();

        if (_currentSelection != null) _selectionResponse.OnSelect(_currentSelection);
    }   
}