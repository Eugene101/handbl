using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle_eneme : MonoBehaviour
{
    public GameObject battery;
    // Start is called before the first frame update
    void Start()
    {
        battery = GameObject.FindWithTag("battery");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(battery.transform.position);
    }
}
