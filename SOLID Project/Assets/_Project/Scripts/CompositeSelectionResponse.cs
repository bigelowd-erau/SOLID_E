using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompositeSelectionResponse : MonoBehaviour, ISelectionResponse, IChangeable
{
    private List<ISelectionResponse> selectionResponses;
    private int _currentIndex = 0;
    private int curSelection;
    private Transform _selection;
    Text label;

    public void Start()
    {
        selectionResponses = GetComponentsInChildren<ISelectionResponse>().ToList();
        selectionResponses.RemoveAt(0);
        label = GameObject.FindGameObjectWithTag("SelectionResponseLabel").GetComponent<Text>();
        label.text = selectionResponses[_currentIndex].GetType().ToString();
    }

    public void Next()
    {
        if (_selection != null)
            selectionResponses[_currentIndex].OnDeselect(_selection);
        _currentIndex = (_currentIndex + 1) % selectionResponses.Count;
        label.text = selectionResponses[_currentIndex].GetType().ToString();
        if (_selection != null)
            selectionResponses[_currentIndex].OnSelect(_selection);
    }

    public void OnSelect(Transform selection)
    {
        _selection = selection;
        if(HasSelection())
            selectionResponses[_currentIndex].OnSelect(selection);
    }

    public void OnDeselect(Transform selection)
    {
        _selection = null;
        if(HasSelection())
            selectionResponses[_currentIndex].OnDeselect(selection);

    }
    private bool HasSelection()
    {
        return (_currentIndex > -1 && _currentIndex < selectionResponses.Count);
    }
}
