using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Opponent : MonoBehaviour
{
    GameObject battery;
    GameObject player;
    Rigidbody rb;
    public float bulletspeed;
    int score;
    
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        battery = GameObject.FindWithTag("battery");
        player = GameObject.FindWithTag("Player");
        transform.LookAt(battery.transform.position + new Vector3 (Random.Range (-20,+20), Random.Range(-2, +2), Random.Range(-10, +10)));
        rb.AddTorque(transform.up * 45f * 10f);
        rb.AddForce(transform.forward * bulletspeed);
    }

    // Update is called once per frame
    void Update()
    {
       // rb.centerOfMass = Vector3.zero;
        
       // rb.freezeRotation = true;
        
        //rb.transform.position = Vector3.Lerp(rb.transform.position, player.transform.position, 0.01f);
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
