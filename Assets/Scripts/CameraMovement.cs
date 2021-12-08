using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offSet;

    private void FixedUpdate()
    {
        transform.position = target.position + offSet;
    }
}
