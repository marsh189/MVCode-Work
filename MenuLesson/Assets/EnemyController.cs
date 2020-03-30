using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector2 moveDirection;
    Rigidbody2D rb;
    GameObject player;

    public float speed = 6;
    public float minDist = 0.2f;
    public float damageAmount = 20;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 direction = playerPos - rb.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (Vector3.Distance(transform.position, playerPos) >= minDist)
        {

            transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "projectile")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
