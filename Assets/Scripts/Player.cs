using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float force = 5f;
    [SerializeField] Transform pivot;

    Camera cam;
    Rigidbody2D rb;
    LineRenderer lineRenderer;

    Vector3 tempPos;
    Vector3 dir;
    Vector3 startPos;
    bool canBeMoved = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
    }
    void Start()
    {
        cam = Camera.main;
        startPos = transform.position;
        lineRenderer.SetPosition(0, pivot.position);
        lineRenderer.SetPosition(1, transform.position);
        RotatePlayer();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            ResetPlayer();
        }
    }

    private void OnMouseDrag()
    {
        if (canBeMoved)
        {
            tempPos = cam.ScreenToWorldPoint(Input.mousePosition);
            tempPos.z = 0f;
            
            if(tempPos.x < pivot.position.x)
            {
                transform.position = tempPos;
            }
            dir = pivot.position - transform.position;
            lineRenderer.SetPosition(1, transform.position);
            RotatePlayer();
        }
    }

    private void OnMouseUp()
    {
        if (canBeMoved)
        {
            rb.gravityScale = 1f;
            rb.AddForce(dir * force, ForceMode2D.Impulse);
            canBeMoved = false;
            lineRenderer.SetPosition(1, pivot.position);
        }
    }

    void ResetPlayer()
    {
        rb.gravityScale = 0f;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        transform.position = startPos;
        canBeMoved = true;
        lineRenderer.SetPosition(1, transform.position);
        RotatePlayer();
    }

    void RotatePlayer()
    {
        Vector3 diff = transform.position - pivot.position;
        diff.Normalize();
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0f, 0f, rotZ + 90f);
    }

}
