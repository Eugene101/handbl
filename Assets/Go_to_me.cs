using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go_to_me : MonoBehaviour
{
    public GameObject player;
    Rigidbody rb;
    public float k = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
     //   transform.LookAt(player.transform.position);
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            print("X pressed");
           // rb.AddForce(transform.forward * k);

        }
    }
}
