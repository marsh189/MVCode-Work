using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Animator animator;

    public int scoreForKill;
    public float maxHealth;
    public Slider healthBar;

    public float speed;
    public float distance;
    public Transform groundCheck;
    bool movingRight = true;

    public int attackTime;
    public float attackRange;
    public Transform playerCheck;
    public LayerMask playerLayer;

    float health;
    int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
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
                    Destroy(player.gameObject);
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
