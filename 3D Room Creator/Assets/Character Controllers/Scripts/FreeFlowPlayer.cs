using TMPro;
using UnityEngine.UI;
using UnityEngine;
using NUnit.Framework.Interfaces;

public class FreeFlowPlayer : MonoBehaviour
{
    public Slider MotionSpeedSlider;
    public TMP_Text MotionSpeedValueText;
    public Camera PreviewCamera;
    public float MoveSpeed = 25f;
    public float SmoothInterpolation = 0.1f;

    private void Awake()
    {
        MotionSpeedSlider.value = MoveSpeed;
        MotionSpeedValueText.text = MoveSpeed.ToString();
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    private void Move()
    {
        Vector2 move = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 cameraForward = PreviewCamera.transform.forward;
        Vector3 cameraRight = PreviewCamera.transform.right;
        Vector3 moveDirection = cameraForward * move.y + cameraRight * move.x;
        Vector3 targetPosition = transform.position + MoveSpeed * Time.deltaTime * moveDirection.normalized;
        transform.position = Vector3.Lerp(transform.position, targetPosition, SmoothInterpolation);

        float upDown = Input.GetAxis("Mouse Y");
        Vector3 verticalMovement = Time.deltaTime * upDown * MoveSpeed * PreviewCamera.transform.up;

        Vector3 targetVerticalPosition = transform.position + verticalMovement;
        transform.position = Vector3.Lerp(transform.position, targetVerticalPosition, SmoothInterpolation);
    }

    private void Rotate()
    {
        if (Input.GetMouseButton(1))
        {
            Vector2 look = new(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            look *= MoveSpeed;

            Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, look.x, 0f));
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, SmoothInterpolation);

            Quaternion targetCameraRotation = Quaternion.Euler(PreviewCamera.transform.rotation.eulerAngles + new Vector3(-look.y, 0f, 0f));
            PreviewCamera.transform.rotation = Quaternion.Lerp(PreviewCamera.transform.rotation, targetCameraRotation, SmoothInterpolation);
        }
    }

    public void Slider_ChangeSpeed()
    {
        MoveSpeed = MotionSpeedSlider.value;
        MotionSpeedValueText.text = MoveSpeed.ToString();
    }
}
