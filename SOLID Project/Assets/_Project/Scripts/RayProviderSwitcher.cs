using UnityEngine;

public class RayProviderSwitcher : Switcher
{
    private void Start()
    {
        nextKeyCode = KeyCode.Alpha2;
        changeableObject = GetComponent<IChangeable>();//(IChangeable)GameObject.FindGameObjectWithTag("SelectionManager").GetComponent<ISelectionResponse>();
    }
}
