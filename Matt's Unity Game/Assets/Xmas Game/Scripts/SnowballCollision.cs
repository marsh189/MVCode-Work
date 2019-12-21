using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballCollision : MonoBehaviour
{

    public string tagToIgnore;

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject obj = col.gameObject;
        if (!obj.tag.Equals(tagToIgnore)) //check if hitting player
        {
            if(obj.tag.Equals("Enemy"))
            {
                Destroy(obj);
            }
            Destroy(this.gameObject);
        }
    }
}
