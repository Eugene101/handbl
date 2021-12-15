using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere_test : MonoBehaviour
{
    GameObject goTo;

    void Start()
    {
        goTo = GameObject.Find("Lifebar_small");
        F1();
    }

    void F1()
    {
        gameObject.transform.LookAt(goTo.transform);
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
    }
}
