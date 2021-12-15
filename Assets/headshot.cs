using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headshot : MonoBehaviour
{

    public GameObject robot_soldier;
    public GameObject fireball;
    public Robot MyScript;
    public bool headshoted;



    //  public GameObject body;




    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {

        fireball.SetActive(false);
        //GameObject obj = GameObject.FindWithTag("Soldier");
        GameObject obj = transform.parent.gameObject;
        MyScript = obj.GetComponent<Robot>();
        //   Animator anim = robot.GetComponent<Animator>();

    }

    // Update is called once per frame
    private void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Bullet" && !headshoted)
        {
            MyScript.setDead();
            headshoted = true;
            MyScript.anim.SetTrigger("Headshot");
            fireball.SetActive(true);
            Invoke("off_fireball", 0.5f);
          //  Invoke("deadman", 2.5f);
            gameObject.GetComponent<Renderer>().enabled = false;
        }

    }
  /*  void deadman()
    {
        MyScript.Die();

    }*/

    void off_fireball()
    {
        MyScript.Die();
        fireball.SetActive(false);
    }
}
