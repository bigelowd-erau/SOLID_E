using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRay
{
    public Vector3 origin { get; set; }
    public Vector3 direction { get; set; }
    public bool Cast(out GameObject hit);
}
