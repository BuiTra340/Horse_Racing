using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] private GameObject frontCamera;
    [SerializeField] private GameObject behindCamera;
    private bool isUsingBehindCamera = true;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(isUsingBehindCamera)
            {
                isUsingBehindCamera = false;
                frontCamera.SetActive(true);
                behindCamera.SetActive(false);
            }else
            {
                isUsingBehindCamera = true;
                frontCamera.SetActive(false);
                behindCamera.SetActive(true);
            }
        }
    }
}
