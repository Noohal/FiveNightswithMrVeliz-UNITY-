using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public Light flashlight;

    public bool isLightOn;

    // Start is called before the first frame update
    void Start()
    {
        isLightOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            isLightOn = true;
        } else
        {
            isLightOn = false;
        }

        if(isLightOn)
        {
            flashlight.enabled = true;
        } else
        {
            flashlight.enabled = false;
        }
    }
}
