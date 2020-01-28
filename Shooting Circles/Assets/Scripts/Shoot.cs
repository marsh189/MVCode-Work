using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Player player;
    public Transform spawnPoint;

    [HideInInspector]
    public Weapon mainWeapon;

    float nextFire;

    float bulletSpeed;

    [HideInInspector]
    public float damage;

    void Start()
    {
        mainWeapon = player.weapon;
        spawnPoint = GameObject.Find("BulletSpawnPoint").transform;
        nextFire = Time.time;

        bulletSpeed = mainWeapon.bulletSpeed * Conversions.bulletSpeed;
        damage = mainWeapon.damage * Conversions.damage;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            if (Time.time >= nextFire)
            {
                Fire();
                nextFire = Time.time + mainWeapon.fireRate;
            }
        }

    }

    void Fire()
    {
        GameObject bullet = Instantiate(mainWeapon.bullet, spawnPoint.position, spawnPoint.rotation) as GameObject;
        bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * bulletSpeed, ForceMode2D.Impulse);
    }
}
