using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Camera[] cameras;
    public Button[] buttons;

    public GameObject securityCamUI;

    public int lastCamera;
    public BoolIntVariable cameraStatus;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = false;
        }
        cameras[0].enabled = true;
        cameraStatus.cond = false;

        // Set Security Panel UI Visibility
        securityCamUI.SetActive(false);
        cameraStatus.val = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //NextCamera();
            if (cameraStatus.cond)
                CloseSecurityPanel();
            else
                OpenSecurityPanel();
        }
    }
    void OpenSecurityPanel()
    {
        cameraStatus.cond = true;
        securityCamUI.SetActive(true);

        if (lastCamera == 0)
            lastCamera = 1;

        ChangeCamera(lastCamera);
    }

    void CloseSecurityPanel()
    {
        cameraStatus.cond = false;
        securityCamUI.SetActive(false);
        ChangeCamera(0);
    }

    void ChangeCamera(int _current)
    {
        cameras[cameraStatus.val].enabled = false;
        cameras[_current].enabled = true;

        buttons[cameraStatus.val].GetComponent<Image>().color = Color.white;
        buttons[_current].GetComponent<Image>().color = Color.green;

        lastCamera = cameraStatus.val;
        cameraStatus.val = _current;
    }

    public void ChangeToCamera1()
    {
        if (cameraStatus.val != 1)
            ChangeCamera(1);
    }

    public void ChangeToCamera2()
    {
        if(cameraStatus.val != 2)
            ChangeCamera(2);
    }

    public void ChangeToCamera3()
    {
        if (cameraStatus.val != 3)
            ChangeCamera(3);
    }

    public void ChangeToCamera4()
    {
        if (cameraStatus.val != 4)
            ChangeCamera(4);
    }

    public void ChangeToCamera5()
    {
        if (cameraStatus.val != 5)
            ChangeCamera(5);
    }

    public void ChangeToCamera6()
    {
        if (cameraStatus.val != 6)
            ChangeCamera(6);
    }

    public void ChangeToCamera7()
    {
        if (cameraStatus.val != 7)
            ChangeCamera(7);
    }

    public void ChangeToCamera8()
    {
        if (cameraStatus.val != 8)
            ChangeCamera(8);
    }

    public void ChangeToCamera9()
    {
        if (cameraStatus.val != 9)
            ChangeCamera(9);
    }

    public void ChangeToCamera10()
    {
        if (cameraStatus.val != 10)
            ChangeCamera(10);
    }

    public void ChangeToCamera11()
    {
        if (cameraStatus.val != 11)
            ChangeCamera(11);
    }



}
