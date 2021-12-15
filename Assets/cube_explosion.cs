using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_explosion : MonoBehaviour
{
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

            MeshExploder script = GetComponent<MeshExploder>();
            script.Explode();

            Destroy(gameObject);
        }



    }
}
