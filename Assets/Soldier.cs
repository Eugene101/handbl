using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public float robotspeed = 0.1f;
    public float robotspeed_walk = 0.1f;
    public GameObject killEffect;
    public GameObject hitEffect;
    public GameObject Smoke;
    public int lifes;
    bool hitted = true;
    int life;
    public GameObject player;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Smoke.gameObject.SetActive(false);
        //transform.LookAt(player.transform.position);
        //transform.rotation = Quaternion.Euler(-10, 0, 0);

        life = lifes;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifes < life && lifes > 0 && hitted)
        {
            anim.SetTrigger("Hitting");
            hitted = false;
            Invoke("hittedOn", 0.5f);
        }

        if (lifes == 0)
        {
            Die();
            lifes = -1;
        }

    }

    void FixedUpdate()
    {

        transform.position = Vector3.Slerp(transform.position, player.transform.position, robotspeed * Time.deltaTime);


        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);

        if ((transform.position - player.transform.position).sqrMagnitude < 10000)
        {
            anim.SetTrigger("Rifling");

        }


    }

    void hittedOn()
    {
        hitted = true;

    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Bullet")
        {
            lifes--;
            robotspeed *= 0.8f;
            GameObject go = Instantiate(hitEffect, transform.position, transform.rotation) as GameObject;
            Destroy(go, 1f);
            Smoke.gameObject.SetActive(true);
            Invoke("Backtorun", 0.5f);




        }
        


    }

    void Backtorun()
    {
      
        if ((transform.position - player.transform.position).sqrMagnitude >= 10000)
        {
            print("zaaaa111");

            anim.SetTrigger("backtorun");
           anim.ResetTrigger("Hitting");

        }

        if ((transform.position - player.transform.position).sqrMagnitude < 10000)
        {
            print("zaaaa");
            anim.SetTrigger("Rifling_after_damage");
            anim.ResetTrigger("Hitting");

        }

    }
    void Die()
    {

        anim.SetTrigger("Diying");

        Smoke.gameObject.SetActive(false);
        GameObject go = Instantiate(killEffect, transform.position, transform.rotation) as GameObject;
        Destroy(go, 1f);
        Destroy(gameObject, 4f);


    }
}