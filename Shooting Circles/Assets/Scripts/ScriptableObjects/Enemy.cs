using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{

    public GameObject gameObject;
    public float health;
    public float speed;
    public float damage;
    public float points;
}
