using UnityEngine;

//enables switching to next of a ray provider type
public class RayProviderSwitcher : Switcher
{
    private void Start()
    {
        nextKeyCode = KeyCode.Alpha2;
        changeableObject = GetComponent<IChangeable>();
    }
}
