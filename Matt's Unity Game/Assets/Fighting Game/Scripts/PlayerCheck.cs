using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            //GetComponentInParent<EnemyController>().animator.SetBool("Walk", false);
            GetComponentInParent<EnemyController>().animator.SetTrigger("Attack");
        }
    }
}
