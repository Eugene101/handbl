using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier_Generator : MonoBehaviour
{
    public int soldiers_limit = 1;
    public GameObject[] soldiers;
    public GameObject born_position;
    Vector3 a;
 

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("F2", 5f, 2f);
    }

    private void Update()
    {
        a = new Vector3(Random.Range(-90, 90), 0, Random.Range(35, 85));
    }

    void F2()
    {
        
        
        GameObject[] soldiers_count = GameObject.FindGameObjectsWithTag("Soldier");
        if (soldiers_count.Length < soldiers_limit)
        {
          
             Instantiate(soldiers[Random.Range(0, soldiers.Length)], a, Quaternion.Euler(0, 0, 0));

            



        }

    }
}
