using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_test : MonoBehaviour
{
    Animator anim;
    public float robotspeed = 0.1f;
    public float robotspeed_walk = 0.1f;
    public float bullet_speed = 0.1f;
    public GameObject killEffect;
    public GameObject hitEffect;
    public GameObject smoke;
    public GameObject bigdamage;
    public GameObject robotic_bullet;
    public GameObject bulletEmittor;
    //  public GameObject Smoke;
    private int health;
    public int lifes;
    public float ShootingDistance;
    public int ammo;
    bool reloading;
    GameObject player;
    GameObject battery;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        battery = GameObject.FindWithTag("battery");
        transform.LookAt(battery.transform.position);
        health = lifes;
        smoke.SetActive(false);
        bigdamage.SetActive(false);

    }



    private void Update()
    {

        if (Input.GetKeyDown("t"))
        {
            Die();
        }

        // transform.LookAt(battery.transform.position);
        float dist1 = Vector3.Distance(transform.position, battery.transform.position);
        print("dist1: " + dist1);

        if (dist1 > ShootingDistance)
        {
            transform.position = Vector3.Slerp(transform.position, battery.transform.position, robotspeed * Time.deltaTime);

        }
        else if (dist1 <= ShootingDistance)
        {
            print("i`m here dist1");

            if (!reloading)
            {
                var robot_bullet = Instantiate(
            robotic_bullet,
           //bulletEmittor.transform.position,
           gameObject.transform.position + new Vector3(2f, 3.5f, -4f),
                       Quaternion.Euler(0f,90f,0f)) as GameObject;
                robot_bullet.gameObject.tag = "robot_bullet";
                robot_bullet.transform.LookAt(battery.transform.position);
                 robot_bullet.GetComponent<Rigidbody>().velocity = transform.forward * bullet_speed;
                robot_bullet.transform.Rotate(Vector3.left * -90);
                reloading = !reloading;
                ammo--;
                Invoke("Reload", 3f);
            }



            anim.SetTrigger("isGo");

        }

        if (ammo == 0)
        {
            Die();
        }

        if (health < lifes && health > 0 && anim != null)
        {

            smoke.SetActive(true);
        }

        if (health == 1 && anim != null)
        {
            bigdamage.SetActive(true);

        }

        if (health == 0 && anim != null)
        {

            Die();
            health = -1;
        }
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Bullet")
        {
            if (health > 0)
            {
                health = health - 1;
                robotspeed *= 0.8f;
                GameObject go = Instantiate(hitEffect, transform.position, transform.rotation) as GameObject;
                Destroy(go, 1f);
            }
        }



    }
    public void Die()
    {
        print("I`m deadman");
        anim.SetTrigger("Die");
        GameObject gop = Instantiate(killEffect, transform.position, transform.rotation) as GameObject;
        Destroy(gop, 4f);
        Destroy(gameObject, 2f);
        refs.score++;
        Destroy(smoke);
        Destroy(bigdamage);
        

    }

    void Reload()
    {
        reloading = !reloading;
    }
}
