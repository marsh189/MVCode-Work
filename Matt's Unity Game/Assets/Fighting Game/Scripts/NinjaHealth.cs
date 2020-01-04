using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NinjaHealth : MonoBehaviour
{
    public Slider healthBar;
    public float maxHealth;
    float health;

    public CanvasGroup deathCanvas;
    LevelManager lm;

    void Start()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
        health = maxHealth;

        deathCanvas.GetComponent<CanvasGroup>().alpha = 0;
        lm = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!lm.gameOver && health <= 0)
        {
            StartCoroutine(lm.FadeCanvas(deathCanvas, 0f, 1f, 1.5f));
        }
        else
        {
            healthBar.value = health;
        }
    }

    public void Damage(float dmg)
    {

        health -= dmg;
        GetComponent<NinjaMovement>().animator.SetTrigger("isHurt");
        Debug.Log(health);
    }
}
