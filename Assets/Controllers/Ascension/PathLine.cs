using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathLine : MonoBehaviour
{
    [SerializeField] Transform[] pathTransforms;


    private void Start()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer != null)
        {
            lineRenderer.positionCount = pathTransforms.Length;
            for(int i = 0; i < pathTransforms.Length; i++)
            {
                lineRenderer.SetPosition(i, pathTransforms[i].position);
            }
        }
    }
}
