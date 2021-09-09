using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class NaiveDistance : MonoBehaviour
{
    private InputDevice inputDevice;
    private List<Vector3> pos = new List<Vector3>();
    private bool isPressed = true;
    private bool wasPressed = false;
    private int counter = 0;
    public trackedDevice tracedDevice = trackedDevice.RIGHTHAND;


    private double naiveDistance = 0;


    Tracking t = new Tracking();


    // Start is called before the first frame update
    void Start()
    {
        t.setup(tracedDevice);

        List<InputDevice> devices = new List<InputDevice>();

        if (tracedDevice == trackedDevice.LEFTHAND)
        {
            InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, devices);

        }
        else
        {
            InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);

        }


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
        //Will track position of a given device while you press the trigger button on targetDevice
        inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out isPressed);

        if (inputDevice != null && isPressed && !wasPressed)
        {
            pos = t.returnTracked(tracedDevice);

            wasPressed = true;
        }


        if (inputDevice != null && !isPressed && wasPressed)
        {
            if (counter % 2 == 0)
            {
                wasPressed = false;
                Debug.Log("The start pos :" + t.returnPos(tracedDevice));
                counter++;
            }
            else
            {
                wasPressed = false;
                Debug.Log("The stop positon:" + t.returnPos(tracedDevice));
                Debug.Log("The distance moved :" + System.Math.Round(t.distance(pos), 2));
                naiveDistance = System.Math.Round(t.distance(pos), 2);
                pos.Clear();
                counter++;
            }
        }
    }
}
