using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float lifeSpan;
    float timer;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < lifeSpan)
        {
            timer += Time.deltaTime;
        }
        else
        {
            animator.SetTrigger("Start");
            if (GetComponent<SpriteRenderer>().color.a == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
