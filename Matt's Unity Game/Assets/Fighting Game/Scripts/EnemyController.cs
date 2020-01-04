using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Animator animator;

    [Header("Health")]
    public int scoreForKill;
    public float maxHealth;
    public Slider healthBar;

    [Header("Movement")]
    public float speed;
    public float distance;
    public Transform groundCheck;
    bool movingRight = true;

    [Header("Attack")]
    public int attackTime;
    public float attackRange;
    public float attackDamage;
    public Transform playerCheck;
    public LayerMask playerLayer;

    float health;
    int timer = 0;

    LevelManager lm;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

        lm = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lm.gameOver)
        {
            this.enabled = false;
        }

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, distance);

            if (groundInfo.collider == false)
            {
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = Vector3.zero;
                    movingRight = true;
                }
            }
        }
        else
        {
            if (timer >= attackTime)
            {
                Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(playerCheck.position, attackRange, playerLayer);

                foreach (Collider2D player in hitPlayers)
                {
                    player.gameObject.GetComponent<NinjaHealth>().Damage(attackDamage);
                }
                timer = 0;
            }
            else
            {
                timer++;
            }
        }
    }

    public int Damage(float dmg)
    {
        health -= dmg;
        healthBar.value = health;
        if(health <= 0)
        {
            //if there is death anim, play it here
            Destroy(gameObject);

            return scoreForKill; //enemy died
        }
        return 0;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(playerCheck.position, attackRange);
    }

}
