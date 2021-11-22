using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

//Enables the switching between different Selectors
public class CompositeSelector : MonoBehaviour, ISelector, IChangeable
{
    private List<ISelector> selectors;
    int _currentIndex = 0;
    Text label;
    public void Start()
    {
        //the possible ray providers are stored in a child GameObject called "SelectorHolder"
        selectors = transform.GetComponentsInChildren<ISelector>().ToList();
        //Remove first element since it will be this CompositeSelector
        selectors.RemoveAt(0);

        label = GameObject.FindGameObjectWithTag("SelectorLabel").GetComponent<Text>();
        //Update UI label on awake
        label.text = selectors[_currentIndex].GetType().ToString();
    }
    public void Check(Stack<Ray> rays)
    {
        selectors[_currentIndex].Check(rays);
    }
    public Transform GetSelection()
    {
        return selectors[_currentIndex].GetSelection();
    }
    private bool HasSelection()
    {
        return _currentIndex > -1 && _currentIndex < selectors.Count;
    }
    public void Next()
    {
        _currentIndex = (_currentIndex + 1) % selectors.Count;
        //Update UI
        label.text = selectors[_currentIndex].GetType().ToString();
    }
}
