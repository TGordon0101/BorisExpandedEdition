using NavMeshPlus.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public NavMeshSurface Mesh2D;

    //// Update is called once per frame
    void Update()
    {
        Mesh2D.UpdateNavMesh(Mesh2D.navMeshData);
    }
}
