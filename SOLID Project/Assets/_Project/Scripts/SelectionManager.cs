using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SelectionManager : MonoBehaviour
{
    private ISelectionResponse _selectionResponse;
    private IRayProvider _rayProvider;
    private ISelector _selector;
    private Transform _currentSelection;

    private void Awake()
    {
        //get first child's selection response this will be the composite
        _selectionResponse = GetComponentsInChildren<ISelectionResponse>()[0];
        //get first child's ray provider this will be the composite
        _rayProvider = GetComponentsInChildren<IRayProvider>()[0];
        //get first child's selector this will be the composite
        _selector = GetComponentsInChildren<ISelector>()[0];
    }

    private void Update()
    {
        if (_currentSelection != null) _selectionResponse.OnDeselect(_currentSelection);

        _selector.Check(_rayProvider.CreateRay());

        _currentSelection = _selector.GetSelection();

        if (_currentSelection != null) _selectionResponse.OnSelect(_currentSelection);
    }   
}