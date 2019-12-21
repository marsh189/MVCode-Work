using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{

    public Transform spawnPoint;
    public GameObject snowball;
    public GameObject canvas;
    public Slider timeSlider;

    public float speed;
    public float upwardForce;

    public bool canShoot;

    void Start()
    {
        canvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            if (timeSlider.value > timeSlider.minValue)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    GameObject clone = Instantiate(snowball, spawnPoint.position, spawnPoint.rotation) as GameObject;
                    if (spawnPoint.localRotation.y == 0)
                    {
                        clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, upwardForce));
                    }
                    else
                    {
                        clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed, upwardForce));
                    }

                    timeSlider.value -= 20;
                }
                timeSlider.value--;
            }
            else
            {
                canShoot = false;
                canvas.SetActive(false);
                timeSlider.value = timeSlider.maxValue;
            }
        }
    }
}
