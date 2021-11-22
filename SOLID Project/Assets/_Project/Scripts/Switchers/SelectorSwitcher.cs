using UnityEngine;

//enables switching to next of a selector type
public class SelectorSwitcher : Switcher
{
    private void Start()
    {
        nextKeyCode = KeyCode.Alpha3;
        changeableObject = GetComponent<IChangeable>();//(IChangeable)GameObject.FindGameObjectWithTag("SelectionManager").GetComponent<ISelectionResponse>();
    }
}