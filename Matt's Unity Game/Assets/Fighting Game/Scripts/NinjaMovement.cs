using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NinjaMovement : MonoBehaviour
{
    [Header("Animation")]
    public NinjaController controller;
    public RuntimeAnimatorController swordAnimatorController;
    public RuntimeAnimatorController animatorController;
    public Animator animator;

    [Header("Attacking")]
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public Text scoreText;
    public int score;
    public bool hasSword;
    public float AttackStrength = 20;

    [Header("Movement")]
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    LevelManager lm;

    void Start()
    {
        lm = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!lm.gameOver)
        {
            scoreText.text = "Score: " + score;

            if (hasSword)
            {
                animator.runtimeAnimatorController = swordAnimatorController;
            }
            else
            {
                animator.runtimeAnimatorController = animatorController;
            }

            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("isJumping", true);
            }

            if (Input.GetButtonDown("Fire1") && hasSword)
            {
                Attack();
            }

            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }
        }

    }

    public void OnLanding()
    {
        
        animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
    
    void Attack()
    {
        controller.isAttacking = true;
        animator.SetTrigger("isAttacking");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            int killScore = enemy.gameObject.GetComponent<EnemyController>().Damage(AttackStrength);
            score += killScore;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}