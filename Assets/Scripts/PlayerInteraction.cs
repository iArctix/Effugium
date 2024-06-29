using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 2.0f; // Distance within which the player can interact
    public TextMeshProUGUI promptText; // Reference to the UI Text element for prompts

    private Camera playerCamera;
    private bool isInspecting = false;
    private InspectableObject currentInspectableObject;

    private void Start()
    {
        playerCamera = Camera.main;
        promptText.text = "";
    }

    private void Update()
    {
        if (isInspecting)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ExitInspectMode();
            }
            else
            {
                promptText.text = "Press E to stop inspecting";
            }
        }
        else
        {
            CheckForObject();
        }
    }

    private void CheckForObject()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            InspectableObject inspectable = hit.collider.GetComponent<InspectableObject>();
            if (inspectable != null)
            {
                promptText.text = "Press E to inspect";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    EnterInspectMode(inspectable);
                }
                return;
            }

            InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();
            if (interactable != null)
            {
                promptText.text = "Press E to interact";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
                return;
            }
        }

        // Clear the prompt text if not looking at any interactable or inspectable object
        promptText.text = "";
    }

    private void EnterInspectMode(InspectableObject inspectable)
    {
        isInspecting = true;
        currentInspectableObject = inspectable;
        currentInspectableObject.EnterInspectMode();
        promptText.text = "Press E to stop inspecting";
    }

    private void ExitInspectMode()
    {
        if (currentInspectableObject != null)
        {
            currentInspectableObject.ExitInspectMode();
            currentInspectableObject = null;
        }
        isInspecting = false;
        promptText.text = "";
    }
}