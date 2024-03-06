using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class FreeFlowPlayer : MonoBehaviour
{
    public Slider MotionSpeedSlider;
    public TMP_Text MotionSpeedValueText;
    public float MoveSpeed = 10f;

    private void Awake()
    {
        MotionSpeedSlider.value = MoveSpeed;
        MotionSpeedValueText.text = MoveSpeed.ToString();
    }

    private void Update()
    {
        Move();

        if (Input.GetMouseButton(1))
        {
            Rotate();
        }
    }

    private void Move()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement vector based on camera's forward direction
        Vector3 movement = MoveSpeed * Time.deltaTime * verticalInput * Camera.main.transform.forward;
        movement += horizontalInput * MoveSpeed * Time.deltaTime * transform.right; // Move relative to camera's right

        // Move the GameObject
        transform.Translate(movement, Space.World);
    }

    private void Rotate()
    {
        // Get input for rotation
        float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = Input.GetAxis("Mouse Y");

        // Calculate rotation
        Vector3 horizontalRotation = (MoveSpeed * 20) * Time.deltaTime * new Vector3(0, rotateHorizontal, 0);
        Vector3 verticalRotation = (MoveSpeed * 20) * Time.deltaTime * new Vector3(-rotateVertical, 0, 0);

        // Rotate the GameObject
        transform.Rotate(horizontalRotation, Space.World);
        Camera.main.transform.Rotate(verticalRotation, Space.Self);
    }

    public void Slider_ChangeSpeed()
    {
        MoveSpeed = MotionSpeedSlider.value;
        MotionSpeedValueText.text = MoveSpeed.ToString();
    }
}
