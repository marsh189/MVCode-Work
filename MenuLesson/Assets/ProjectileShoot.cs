using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject projectile;
    public float speed = 20;

    public float fireRate = 0.25f;
    float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time >= nextFire)
            {
                Fire();
                nextFire = Time.time + fireRate;
            }
        }
    }

    void Fire()
    {
        GameObject clone = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation) as GameObject;
        clone.GetComponent<Rigidbody2D>().AddForce(clone.transform.right * speed, ForceMode2D.Impulse);
    }

 
}
