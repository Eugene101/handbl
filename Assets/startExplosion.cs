using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startExplosion : MonoBehaviour { 
    public MeshExploder script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            script.Explode();
            Destroy(gameObject, 0.1f);
        }

    }
}
