using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightbulb : MonoBehaviour
{
    public bool lighton;
    public Material emission;
    public Light spotlight;

    // Start is called before the first frame update
    void Start()
    {
        emission.EnableKeyword("_EMISSION");
        lighton = true;
        spotlight.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLightState();
    }

    public void ToggleLight()
    {
        lighton = !lighton;
        UpdateLightState();
    }

    private void UpdateLightState()
    {
        if (!lighton)
        {
            emission.DisableKeyword("_EMISSION");
            spotlight.enabled = false;
        }
        else
        {
            spotlight.enabled = true;
            emission.EnableKeyword("_EMISSION");
        }
    }
}