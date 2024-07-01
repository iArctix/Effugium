using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Lightbulb lightbulb; // Reference to the Lightbulb script

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerLookingAtSwitch())
        {
            lightbulb.ToggleLight();
        }
    }

    private bool IsPlayerLookingAtSwitch()
    {
        Camera playerCamera = Camera.main; // Assuming the main camera is the player's camera
        if (playerCamera != null)
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition); // Ray from the camera to the mouse position
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 5.0f)) // Adjust the distance as needed
            {
                if (hit.transform == transform)
                {
                    return true;
                }
            }
        }

        return false;
    }
}