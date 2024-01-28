using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    float dragSpeed = 1f;

    float outerLeft = -10f;
    float outerRight = 10f;
    float outerUp = 10f;
    float outerBottom = -10f;
    [SerializeField] Camera camera;


    void Update()
    {


        if (!Input.GetMouseButton(0)) return;
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        if (transform.position.x > outerRight && mouseX < 0) return;
        if (transform.position.x < outerLeft && mouseX > 0) return;
        if (transform.position.y > outerUp && mouseY < 0) return;
        if (transform.position.y < outerBottom && mouseY > 0) return;


        camera.transform.position -= new Vector3(mouseX * dragSpeed, mouseY * dragSpeed, 0);
    }
}
