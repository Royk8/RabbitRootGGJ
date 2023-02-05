using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SpeedVr : MonoBehaviour
{
    InputDevice LeftControllerDevice;
    InputDevice RightControllerDevice;
    Vector3 LeftControllerVelocity;
    Vector3 RightControllerVelocity;


    void Start()
    {
        LeftControllerDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        RightControllerDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }


    void Update()
    {
        UpdateInput();
    }

     void UpdateInput()
    {
        LeftControllerDevice.TryGetFeatureValue(CommonUsages.deviceVelocity, out LeftControllerVelocity);
    }
}
