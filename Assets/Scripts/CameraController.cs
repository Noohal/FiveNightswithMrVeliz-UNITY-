using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Camera[] cameras;
    public Button[] buttons;

    public GameObject securityCamUI;

    public BoolVariable lookingAtSecurityScreen;
    public int lastCamera;
    public int currentCamera;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = false;
        }
        cameras[0].enabled = true;
        lookingAtSecurityScreen.value = false;

        // Set Security Panel UI Visibility
        securityCamUI.SetActive(false);
        currentCamera = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //NextCamera();
            if (lookingAtSecurityScreen.value)
                CloseSecurityPanel();
            else
                OpenSecurityPanel();
        }
    }
    void NextCamera()
    {
        lastCamera = currentCamera;
        lookingAtSecurityScreen.value = true;
        cameras[currentCamera].enabled = false;
        currentCamera++;
        if (currentCamera >= cameras.Length)
        {
            currentCamera = 0;
            lookingAtSecurityScreen.value = false;
        }
        cameras[currentCamera].enabled = true;
    }

    void OpenSecurityPanel()
    {
        lookingAtSecurityScreen.value = true;
        securityCamUI.SetActive(true);
        ChangeCamera(1);
    }

    void CloseSecurityPanel()
    {
        lookingAtSecurityScreen.value = false;
        securityCamUI.SetActive(false);
        ChangeCamera(0);
    }

    void ChangeCamera(int _current)
    {
        cameras[currentCamera].enabled = false;
        cameras[_current].enabled = true;

        lastCamera = currentCamera;
        currentCamera = _current;
    }

    public void ChangeToCamera1()
    {
        if (currentCamera != 1)
            ChangeCamera(1);
    }

    public void ChangeToCamera2()
    {
        if(currentCamera != 2)
            ChangeCamera(2);
    }

    public void ChangeToCamera3()
    {
        if (currentCamera != 3)
            ChangeCamera(3);
    }

    public void ChangeToCamera4()
    {
        if (currentCamera != 4)
            ChangeCamera(4);
    }

    public void ChangeToCamera5()
    {
        if (currentCamera != 5)
            ChangeCamera(5);
    }

    public void ChangeToCamera6()
    {
        if (currentCamera != 6)
            ChangeCamera(6);
    }

    public void ChangeToCamera7()
    {
        if (currentCamera != 7)
            ChangeCamera(7);
    }

    public void ChangeToCamera8()
    {
        if (currentCamera != 8)
            ChangeCamera(8);
    }

    public void ChangeToCamera9()
    {
        if (currentCamera != 9)
            ChangeCamera(9);
    }

    public void ChangeToCamera10()
    {
        if (currentCamera != 10)
            ChangeCamera(10);
    }

    public void ChangeToCamera11()
    {
        if (currentCamera != 11)
            ChangeCamera(11);
    }



}
