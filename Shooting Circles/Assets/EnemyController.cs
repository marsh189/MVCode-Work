using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy enemy;
    Rigidbody2D rb;
    GameObject player;
    public float MinDist = 0.2f;

    Vector2 moveDirection;
    float health;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        health = enemy.health;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 direction = playerPos - rb.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (Vector3.Distance(transform.position, player.transform.position) >= MinDist)
        {

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemy.speed * Time.deltaTime);
        }
    }


    void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            Physics2D.IgnoreCollision(collision.otherCollider, GetComponent<CircleCollider2D>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            TakeDamage(player.GetComponent<Shoot>().mainWeapon.damage);
        }
    }
}
