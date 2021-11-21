using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
public class CompositeSelector : MonoBehaviour, ISelector, IChangeable
{
    private List<ISelector> selectors;
    int _currentIndex = 0;
    Text label;
    public void Start()
    {
        selectors = transform.GetComponentsInChildren<ISelector>().ToList();
        selectors.RemoveAt(0);
        label = GameObject.FindGameObjectWithTag("SelectorLabel").GetComponent<Text>();
        label.text = selectors[_currentIndex].GetType().ToString();
        //foreach (IRayProvider rp in rayProviders)
        //Debug.Log("2: " + rp);
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
        label.text = selectors[_currentIndex].GetType().ToString();
        //Debug.Log("Selector set to "+ selectors[_currentIndex]);
    }
}
