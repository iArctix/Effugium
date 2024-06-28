using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public Transform openTransform; // Transform when the object is open (includes position and rotation)
    public Transform closedTransform; // Transform when the object is closed (includes position and rotation)
    public float animationSpeed = 2.0f; // Speed of the opening/closing animation

    private bool isOpen = false; // State of the object
    private bool isAnimating = false; // Check if currently animating
    private Transform targetTransform; // Target transform for animation

    private void Start()
    {
        targetTransform = closedTransform; // Initially set to closed transform
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
        transform.position = Vector3.Lerp(transform.position, targetTransform.position, Time.deltaTime * animationSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetTransform.rotation, Time.deltaTime * animationSpeed);

        if (Vector3.Distance(transform.position, targetTransform.position) < 0.01f && Quaternion.Angle(transform.rotation, targetTransform.rotation) < 1.0f)
        {
            transform.position = targetTransform.position; // Snap to target position
            transform.rotation = targetTransform.rotation; // Snap to target rotation
            isAnimating = false; // Stop animating
        }
    }

    public void Interact()
    {
        if (!isAnimating)
        {
            isOpen = !isOpen;
            targetTransform = isOpen ? openTransform : closedTransform;
            isAnimating = true;
        }
    }
}