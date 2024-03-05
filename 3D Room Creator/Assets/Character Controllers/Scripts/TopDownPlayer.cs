using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayer : MonoBehaviour
{
    public Camera PreviewCamera;
    public float MoveSpeed = 0.1f;

    private void FixedUpdate()
    {
        MoveAround();
        RotateCamera();
    }

    public void MoveAround()
    {
        Vector2 move = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 cameraForward = PreviewCamera.transform.forward;
        Vector3 cameraRight = PreviewCamera.transform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        Vector3 moveDirection = cameraForward.normalized * move.y + cameraRight.normalized * move.x;

        if (moveDirection.magnitude > 1f) moveDirection.Normalize();
        transform.position += moveDirection * MoveSpeed;
    }

    public void RotateCamera()
    {
        if (Input.GetKey(KeyCode.E))
        {
            PreviewCamera.transform.Rotate(0, 20 * MoveSpeed, 0, Space.World);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            PreviewCamera.transform.Rotate(0, -20 * MoveSpeed, 0, Space.World);
        }
    }
}
