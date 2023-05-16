using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 offset;
    Vector3 tempPos;
    void Start()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        tempPos = target.position + offset;
        tempPos.y = 0f;
        transform.position = tempPos;
    }
}
