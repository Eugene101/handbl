using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Grabline : MonoBehaviour
{
    public GameObject Grabcylynder;
    bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        Grabcylynder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         //OVRInput.Update();
         if (OVRInput.GetDown(OVRInput.RawButton.X) && !isOn) 
         {
             print("grab on");
             Grabcylynder.SetActive(true);
             isOn = !isOn;
         }
        else if (OVRInput.GetDown(OVRInput.RawButton.X) && isOn)
         {
             print("grab off");
             Grabcylynder.SetActive(false);
             isOn = !isOn;
         }
 
    }
}


