using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Enables the switching between different SelectionResponses
public class CompositeSelectionResponse : MonoBehaviour, ISelectionResponse, IChangeable
{
    private List<ISelectionResponse> selectionResponses;
    private int _currentIndex = 0;
    private int curSelection;
    private Transform _selection;
    Text label;

    public void Start()
    {
        //the possible ray providers are stored in a child GameObject called "SelectionResponseHolder"
        selectionResponses = GetComponentsInChildren<ISelectionResponse>().ToList();
        //Remove first element since it will be this CompositeRayProvider
        selectionResponses.RemoveAt(0);

        label = GameObject.FindGameObjectWithTag("SelectionResponseLabel").GetComponent<Text>();
        //Update UI label on awake
        label.text = selectionResponses[_currentIndex].GetType().ToString();
    }

    public void Next()
    {
        //Deselect current selection
        if (_selection != null)
            selectionResponses[_currentIndex].OnDeselect(_selection);
        _currentIndex = (_currentIndex + 1) % selectionResponses.Count;
        //Update UI
        label.text = selectionResponses[_currentIndex].GetType().ToString();
        //Select current selection
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
