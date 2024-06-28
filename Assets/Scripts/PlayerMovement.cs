using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float lookSpeed = 2.0f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    private bool controlsEnabled = true;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (controlsEnabled)
        {
            // Movement
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = transform.right * moveHorizontal + transform.forward * moveVertical;
            transform.position += movement * speed * Time.deltaTime;

            // Mouse look
            rotationX += Input.GetAxis("Mouse X") * lookSpeed;
            rotationY -= Input.GetAxis("Mouse Y") * lookSpeed;
            rotationY = Mathf.Clamp(rotationY, -90, 90);

            transform.localRotation = Quaternion.Euler(0, rotationX, 0);
            Camera.main.transform.localRotation = Quaternion.Euler(rotationY, 0, 0);
        }
    }

    public void EnableControls(bool enable)
    {
        controlsEnabled = enable;
        Cursor.lockState = enable ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !enable;
    }
}