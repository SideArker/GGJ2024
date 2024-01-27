using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrestigeLine : MonoBehaviour
{
    LineRenderer lineRenderer;

    public void init(Vector3 startPos, Vector3 endPos)
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}
