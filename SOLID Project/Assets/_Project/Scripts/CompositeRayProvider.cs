using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CompositeRayProvider : MonoBehaviour, IRayProvider, IChangeable
{
    private List<IRayProvider> rayProviders;
    int _currentIndex = 0;
    Text label;
    public void Start()
    {
        rayProviders = transform.GetComponentsInChildren<IRayProvider>().ToList();
        rayProviders.RemoveAt(0);
        label = GameObject.FindGameObjectWithTag("RayProviderLabel").GetComponent<Text>();
        label.text = rayProviders[_currentIndex].GetType().ToString();
    }

    public Stack<Ray> CreateRay()
    {
        if (HasSelection())
            return rayProviders[_currentIndex].CreateRay();
        return null;
    }
    public void Next()
    {
        _currentIndex = (_currentIndex + 1) % rayProviders.Count;
        label.text = rayProviders[_currentIndex].GetType().ToString();
        //Debug.Log("Ray Provider set to " + rayProviders[_currentIndex]);
    }
    private bool HasSelection()
    {
        return _currentIndex > -1 && _currentIndex < rayProviders.Count;
    }
}
