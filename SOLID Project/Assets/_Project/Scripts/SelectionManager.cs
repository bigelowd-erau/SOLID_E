using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private ISelectionResponse _selectionResponse;
    private IRayProvider _rayProvider;
    private ISelector _selector;
    private Transform _currentSelection;

    private void Awake()
    {
        _selectionResponse = GetComponentsInChildren<ISelectionResponse>()[0];
        _rayProvider = GetComponentsInChildren<IRayProvider>()[0];
        _selector = GetComponentsInChildren<ISelector>()[0];
    }

    private void Update()
    {
        if (_currentSelection != null) _selectionResponse.OnDeselect(_currentSelection);

        //Stack<Ray> ray = _rayProvider.CreateRay();

        //Selection Determination
        _selector.Check(_rayProvider.CreateRay());

        _currentSelection = _selector.GetSelection();

        if (_currentSelection != null) _selectionResponse.OnSelect(_currentSelection);
    }   
}