using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifebar : MonoBehaviour
{
   
    public GameObject lifeBar;
    public int lifes_lifebar = 20;
    public static float upp = 0.5f;
    public float k = 1f;
    public GameObject endofbar;
    // Start is called before the first frame update
    void Start()
    {
        refs.score = 20;
        lifeBar.transform.localScale = new Vector3(lifeBar.transform.localScale.x, refs.score * 20 / lifes_lifebar, lifeBar.transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.tag == "Bullet")
        {
            refs.score--;

            lifeBar.transform.localScale = new Vector3(lifeBar.transform.localScale.x, refs.score*20/lifes_lifebar, lifeBar.transform.localScale.z);
          
            /* upp += 0.1f;

            if (lifeBar.transform.position.y < endofbar.transform.position.y)
            {

            

            lifeBar.transform.position += new Vector3 (0f, upp*k, 0f);
           
            }

            else if (lifeBar.transform.position.y >= transform.position.y)
            {
                print("I`m full");
            }*/
        }



    }
}
