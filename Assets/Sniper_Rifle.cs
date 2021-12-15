using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper_Rifle : MonoBehaviour
{

    public float bulletLife = 1f;
    public GameObject bulletPrefab;
    public GameObject bulletEmittor;
    public float bullet_speed = 0.01f;
   // public Camera ScopeCamera;
   // public Camera MainCamera;
    public bool ScopeOnOff;

    private void Awake()
    {
       // ScopeCamera.enabled = false;
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {

            GameObject bullet = SpawnBullet();
            ShootBullet(bullet);
            KillBullet(bullet);
        }
       /* if (OVRInput.GetDown(OVRInput.Touch.Two) && !ScopeOnOff)
        {
            print("Vasyya");
            ScopeCamera.enabled = true ;
            MainCamera.enabled = false;
            ScopeOnOff = !ScopeOnOff;
        }

        if (OVRInput.GetDown(OVRInput.Touch.Two) && ScopeOnOff)
        {
            ScopeCamera.enabled = false;
            MainCamera.enabled = true;
            ScopeOnOff = !ScopeOnOff;
        }*/

    }





    GameObject SpawnBullet()
    {
        var bullet = Instantiate(
            bulletPrefab,
           bulletEmittor.transform.position,
            transform.rotation) as GameObject;
        bullet.gameObject.tag = "Bullet";

        // bullet.transform.Rotate(Vector3.left * -90);
        return bullet;
    }

    void ShootBullet(GameObject bullet)
    {

        bullet.GetComponent<Rigidbody>().velocity = bulletEmittor.transform.right * bullet_speed;
        bullet.transform.Rotate(Vector3.forward * 90);
    }

    void KillBullet(GameObject bullet)
    {
        Destroy(bullet, bulletLife);
    }

    /*void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name +"***");
    }*/
}
