using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public Transform openPosition; // Position when the object is open
    public Transform closedPosition; // Position when the object is closed
    public float animationSpeed = 2.0f; // Speed of the opening/closing animation

    private bool isOpen = false; // State of the object
    private bool isAnimating = false; // Check if currently animating
    private Vector3 targetPosition; // Target position for animation
    private Quaternion targetRotation; // Target rotation for animation

    private void Start()
    {
        targetPosition = closedPosition.position; // Initially set to closed position
        targetRotation = closedPosition.rotation; // Initially set to closed rotation
    }

    private void Update()
    {
        if (isAnimating)
        {
            AnimateObject();
        }
    }

    private void AnimateObject()
    {
        // Move and rotate the object
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * animationSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * animationSpeed);

        // Check if the animation is close to completion
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f && Quaternion.Angle(transform.rotation, targetRotation) < 0.01f)
        {
            transform.position = targetPosition; // Snap to target position
            transform.rotation = targetRotation; // Snap to target rotation
            isAnimating = false; // Stop animating
        }
    }

    public void Interact()
    {
        if (!isAnimating)
        {
            isOpen = !isOpen;
            targetPosition = isOpen ? openPosition.position : closedPosition.position;
            targetRotation = isOpen ? openPosition.rotation : closedPosition.rotation;
            isAnimating = true;
        }
    }
}