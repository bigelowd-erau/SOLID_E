using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

//Enables the switching between different Ray Providers
public class CompositeRayProvider : MonoBehaviour, IRayProvider, IChangeable
{
    private List<IRayProvider> rayProviders;
    int _currentIndex = 0;
    Text label;
    public void Start()
    {
        //the possible ray providers are stored in a child GameObject called "RayProviderHolder"
        rayProviders = transform.GetComponentsInChildren<IRayProvider>().ToList();
        //Remove first element since it will be this CompositeRayProvider
        rayProviders.RemoveAt(0);

        label = GameObject.FindGameObjectWithTag("RayProviderLabel").GetComponent<Text>();
        //Update UI label on awake
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
        //Update UI
        label.text = rayProviders[_currentIndex].GetType().ToString();
    }
    private bool HasSelection()
    {
        return _currentIndex > -1 && _currentIndex < rayProviders.Count;
    }
}
