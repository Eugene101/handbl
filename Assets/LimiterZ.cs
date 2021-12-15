using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiterZ : MonoBehaviour
{
    public float z =4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.transform.position.z >=z)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, z);
            // gameObject.transform.position = new Vector3(0,2,0);
            print("teleport");
        }
    }
}
