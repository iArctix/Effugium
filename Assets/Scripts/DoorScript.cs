using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorScript : MonoBehaviour
{
    public bool currentlevelcomplete = false;
    public GameObject door;

    private RoomManager roomManager;
    private GameObject promptObject;
    private TextMeshProUGUI prompt;

    [System.Obsolete]
    void Start()
    {

        roomManager = FindObjectOfType<RoomManager>(); // Find the RoomManager in the scene

        // Find the prompt object and text in the scene
        promptObject = GameObject.Find("Promptui"); // Replace with the actual name of the prompt object
        if (promptObject != null)
        {
            prompt = promptObject.GetComponentInChildren<TextMeshProUGUI>();
            promptObject.SetActive(false);
        }
    }

    void Update()
    {
        if (promptObject != null && promptObject.activeSelf && Input.GetKeyDown(KeyCode.E) && currentlevelcomplete)
        {
            roomManager.CompleteRoom();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (promptObject != null)
            {
                promptObject.SetActive(true);
                if (currentlevelcomplete)
                {
                    prompt.text = "Press E to Enter The Next Room";
                }
                else
                {
                    prompt.text = "Door Locked";
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (promptObject != null)
            {
                promptObject.SetActive(false);
                prompt.text = " ";
            }
        }
    }
}