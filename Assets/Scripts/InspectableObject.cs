using UnityEngine;

public class InspectableObject : MonoBehaviour
{
    public float inspectDistance = 1.5f; // Distance from the camera during inspection
    public float rotationSpeed = 300.0f; // Speed of rotation when dragging
    private bool isInspecting = false;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Camera mainCamera;
    private bool isDragging = false;

    private void Start()
    {
        mainCamera = Camera.main;
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        if (isInspecting)
        {
            HandleRotation();
            if (Input.GetKeyDown(KeyCode.E))
            {
                ExitInspectMode();
            }
        }
    }

    public void EnterInspectMode()
    {
        isInspecting = true;
        initialPosition = transform.position;
        initialRotation = transform.rotation;

        // Move the object in front of the camera
        transform.position = mainCamera.transform.position + mainCamera.transform.forward * inspectDistance;

        // Disable the player controls
        PlayerMovement playerMovement = mainCamera.GetComponentInParent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.EnableControls(false);
        }
    }

    public void ExitInspectMode()
    {
        isInspecting = false;
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        // Re-enable the player controls
        PlayerMovement playerMovement = mainCamera.GetComponentInParent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.EnableControls(true);
        }
    }

    private void HandleRotation()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            float xRotation = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float yRotation = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            transform.Rotate(mainCamera.transform.up, -xRotation, Space.World);
            transform.Rotate(mainCamera.transform.right, yRotation, Space.World);
        }
    }
}