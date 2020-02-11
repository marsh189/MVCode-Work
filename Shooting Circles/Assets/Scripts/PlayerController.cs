﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Player player;
    public Slider healthSlider;
    public Slider shieldSlider;
    public Text scoreText;

    Vector2 mousePosition;

    Vector2 movement;
    Rigidbody2D rb;
    float health;
    float shield;
    public float speed;
    LevelManager lm;

    [HideInInspector]
    public float score;

    void Start()
    {
        player = SavedData.SetUpPlayer(player);

        Instantiate(player.obj, this.transform);
        rb = GetComponent<Rigidbody2D>();
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        health = player.health * Conversions.health;
        shield = player.shield * Conversions.shield;
        speed = player.speed * Conversions.speed;
        score = player.score;

        healthSlider.maxValue = health;
        shieldSlider.maxValue = shield;



    }

    // Update is called once per frame
    void Update()
    {
        shieldSlider.value = shield;
        healthSlider.value = health;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        if (lm.gameState == "Playing")
        {
            Move();
            MouseRotate();
            if (score > 0)
            {
                scoreText.text = score.ToString();
            }
        }
        else
        {
            scoreText.text = "";
        }

        if(lm.gameState == "Game Over")
        {
            SavePlayerInfo();
        }
    }

    public void SavePlayerInfo()
    {
        PlayerPrefs.SetFloat("Player Score", score);
        PlayerPrefs.SetFloat("Player Shield", player.shield);
        PlayerPrefs.SetFloat("Player Health", player.health);
        PlayerPrefs.SetFloat("Player Speed", player.speed);
        PlayerPrefs.Save();
    }

    void MouseRotate()
    {

        Vector2 direction = mousePosition - rb.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    void Move()
    {

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    public void TakeDamage(float damage)
    {
        Camera.main.gameObject.GetComponent<CameraShake>().CamShakePlayer();

        if (shield >= damage)
        {
            shield -= damage;
        }
        else
        {
            float leftOver = 0;
            if (shield > 0)
            {
                leftOver = damage - shield;
                shield = 0;
                health -= leftOver;
            }
            else if(shield <= 0)
            {
                health -= damage;
            }

        }

        if(health <= 0)
        {
            lm.gameState = "Game Over";
        }
    }

    public void HandleScore(float s)
    {
        this.score += s;
    }
}
