using UnityEngine;
using System.Collections.Generic;

public interface ISelector
{
    void Check(Stack<Ray> ray);
    Transform GetSelection();
}