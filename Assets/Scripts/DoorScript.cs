using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorScript : MonoBehaviour
{
    public GameObject trigger;
    public GameObject promptobject;
    public TextMeshProUGUI prompt;
    public bool currentlevelcomplete = false;

    public GameObject door;
  
    void Start()
    {
        promptobject.SetActive(false);
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            promptobject.SetActive(true);
            if(currentlevelcomplete == true)
            {
                prompt.text = "Press E to Enter The Next Room";
            }
            if(currentlevelcomplete == false)
            {
                prompt.text = "Door Locked";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            promptobject.SetActive(true);
            prompt.text = " ";
        }
    }

    
}
