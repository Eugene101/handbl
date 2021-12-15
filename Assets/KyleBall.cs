using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KyleBall : MonoBehaviour
{
    GameObject battery;
    Rigidbody rb;
    public float bulletspeed;
    int score;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        battery = GameObject.FindWithTag("battery");
       
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "battery")
        {
            score++;
            print("score: " + score);
            Destroy(gameObject, 1f);
        }

    }

}
