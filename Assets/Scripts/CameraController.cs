using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera[] cameras;

    public int currentCamera = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            NextCamera();
        }
    }

    void NextCamera()
    {
        cameras[currentCamera].enabled = false;
        currentCamera++;
        if(currentCamera >= cameras.Length)
        {
            currentCamera = 0;
        }
        cameras[currentCamera].enabled = true;
    }
}
