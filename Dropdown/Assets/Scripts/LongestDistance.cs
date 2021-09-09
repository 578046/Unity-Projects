using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class LongestDistance : MonoBehaviour
{
    private InputDevice inputDevice;
    private List<Vector3> pos = new List<Vector3>();
    public trackedDevice tracedDevice;

    private bool isPressed = true;
    private bool wasPressed = false;

    Tracking tracking = new Tracking();

    double longestDistance = 0; //used in visualization

    // Start is called before the first frame update

    void Start()
    {
        tracking.setup(tracedDevice);

        List<InputDevice> devices = new List<InputDevice>();

        if (tracedDevice == trackedDevice.LEFTHAND)
        {
            InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, devices);

        }
        else
        {
            InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);

        }

        Debug.Log(devices.Count());


        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            inputDevice = devices[0];
        }
    }


    // Update is called once per frame
    void Update()
    {
        inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out isPressed);

        if (inputDevice != null && isPressed && !wasPressed)
        {
            wasPressed = true;
        }

        if (inputDevice != null && wasPressed)
        {
            pos = tracking.returnTracked(tracedDevice);
            longestDistance = tracking.distance(pos);
            Debug.Log(tracking.distance(pos));
        }

    }
}
