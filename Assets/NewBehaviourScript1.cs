﻿using System.Collections;
using System.Linq;

using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    void Start ()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.triangles = mesh.triangles.Reverse().ToArray();
    }
}