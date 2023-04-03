using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed;
    public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 pos = transform.position + offset;
        Vector3 smoothFollow = Vector3.Lerp(target.position,pos, smoothSpeed);
        transform.position = smoothFollow ;
    }
}
