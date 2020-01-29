﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Player")]
public class Player : ScriptableObject
{
    public float speed = 5f;
    public float health = 5f;
    public float shield = 5f;

    public Weapon weapon;

}
