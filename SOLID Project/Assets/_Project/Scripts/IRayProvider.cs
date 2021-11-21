using UnityEngine;
using System.Collections.Generic;

public interface IRayProvider
{
    Stack<Ray> CreateRay();
}