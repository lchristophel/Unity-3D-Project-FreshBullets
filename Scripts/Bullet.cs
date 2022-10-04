using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    public int power;
    public AudioClip gunSound;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().PlayOneShot(gunSound);
            GameObject shot = (GameObject) Instantiate(bullet, this.transform.position, Quaternion.identity);
            shot.GetComponent<Rigidbody>().AddForce(this.transform.forward * power);
        }
    }
}
