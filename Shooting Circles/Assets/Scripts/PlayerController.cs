using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Player player;
    Vector2 mousePosition;

    float health;
    Animator animator;
    Vector2 movement;
    Rigidbody2D rb;

    bool isDead;

    public Slider healthSlider;
    public Slider shieldSlider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = player.health;

        healthSlider.maxValue = health;
        healthSlider.value = health;

        shieldSlider.maxValue = player.shield;
        shieldSlider.value = player.shield;
    }

    // Update is called once per frame
    void Update()
    {

        healthSlider.value = health;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            Move();
            MouseRotate();
        }
        else
        {
            GameObject.Find("LevelManager").GetComponent<LevelManager>().gameStatus = "Game Over";
        }
    }

    void MouseRotate()
    {

        Vector2 direction = mousePosition - rb.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    void Move()
    {

        rb.MovePosition(rb.position + movement * player.speed * Time.fixedDeltaTime);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log(health);
        health -= damage;
        animator.SetTrigger("Hit");
        if(health <= 0)
        {
            isDead = true;
        }
    }
}
