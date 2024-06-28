using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 2.0f; // Distance within which the player can interact
    private Camera playerCamera;
    private bool isInspecting = false;
    private InspectableObject currentInspectableObject;

    private void Start()
    {
        playerCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isInspecting)
        {
            Interact();
        }
        else if (Input.GetKeyDown(KeyCode.E) && isInspecting)
        {
            ExitInspectMode();
        }
    }

    private void Interact()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            InspectableObject inspectable = hit.collider.GetComponent<InspectableObject>();
            if (inspectable != null)
            {
                EnterInspectMode(inspectable);
            }
        }
    }

    private void EnterInspectMode(InspectableObject inspectable)
    {
        isInspecting = true;
        currentInspectableObject = inspectable;
        currentInspectableObject.EnterInspectMode();
    }

    private void ExitInspectMode()
    {
        if (currentInspectableObject != null)
        {
            currentInspectableObject.ExitInspectMode();
            currentInspectableObject = null;
        }
        isInspecting = false;
    }
}