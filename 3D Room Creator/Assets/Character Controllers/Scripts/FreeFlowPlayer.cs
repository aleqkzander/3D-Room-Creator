using UnityEngine;

public class FreeFlowPlayer : MonoBehaviour
{
    public Camera PreviewCamera;
    public float MoveSpeed = 5f;
    public float SmoothInterpolation = 0.1f;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector2 move = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 cameraForward = PreviewCamera.transform.forward;
        Vector3 cameraRight = PreviewCamera.transform.right;
        Vector3 moveDirection = cameraForward * move.y + cameraRight * move.x;
        Vector3 targetPosition = transform.position + MoveSpeed * Time.fixedDeltaTime * moveDirection.normalized;
        transform.position = Vector3.Lerp(transform.position, targetPosition, SmoothInterpolation);

        float upDown = Input.GetAxis("Mouse Y");
        Vector3 verticalMovement = Time.fixedDeltaTime * upDown * MoveSpeed * PreviewCamera.transform.up;

        Vector3 targetVerticalPosition = transform.position + verticalMovement;
        transform.position = Vector3.Lerp(transform.position, targetVerticalPosition, SmoothInterpolation);
    }

    private void Rotate()
    {
        if (Input.GetMouseButton(2))
        {
            float mouseX = Input.GetAxis("Mouse X") * MoveSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * MoveSpeed;

            Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, mouseX, 0f));
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, SmoothInterpolation);

            Quaternion targetCameraRotation = Quaternion.Euler(PreviewCamera.transform.rotation.eulerAngles + new Vector3(-mouseY, 0f, 0f));
            PreviewCamera.transform.rotation = Quaternion.Lerp(PreviewCamera.transform.rotation, targetCameraRotation, SmoothInterpolation);
        }
    }
}
