using UnityEngine;

//enables switching to next of a selection response type
public class SelectionResponseSwitcher: Switcher
{
    private void Start()
    {
        nextKeyCode = KeyCode.Alpha1;
        changeableObject = GetComponent<IChangeable>();//(IChangeable)GameObject.FindGameObjectWithTag("SelectionManager").GetComponent<ISelectionResponse>();
    }
}
