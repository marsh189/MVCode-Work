using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestMenu : MonoBehaviour
{
    public Player[] playerTypes;
    public Weapon[] weaponTypes;
    public Player currentPlayer;
    public Weapon currentWeapon;

    public void Base()
    {
        currentPlayer.shield = playerTypes[0].shield;
        currentPlayer.health = playerTypes[0].health;
        currentPlayer.speed = playerTypes[0].speed;
    }
    public void Tank()
    {
        currentPlayer.shield = playerTypes[1].shield;
        currentPlayer.health = playerTypes[1].health;
        currentPlayer.speed = playerTypes[1].speed;
    }
    public void Speedy()
    {
        currentPlayer.shield = playerTypes[2].shield;
        currentPlayer.health = playerTypes[2].health;
        currentPlayer.speed = playerTypes[2].speed;
    }

    public void BaseWeapon()
    {
        currentWeapon.fireRate = weaponTypes[0].fireRate;
        currentWeapon.bulletSpeed = weaponTypes[0].bulletSpeed;
        currentWeapon.damage = weaponTypes[0].damage;
    }
    public void AutoWeapon()
    {
        currentWeapon.fireRate = weaponTypes[1].fireRate;
        currentWeapon.bulletSpeed = weaponTypes[1].bulletSpeed;
        currentWeapon.damage = weaponTypes[1].damage;
    }
    public void HeavyWeapon()
    {
        currentWeapon.fireRate = weaponTypes[2].fireRate;
        currentWeapon.bulletSpeed = weaponTypes[2].bulletSpeed;
        currentWeapon.damage = weaponTypes[2].damage;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }
}
