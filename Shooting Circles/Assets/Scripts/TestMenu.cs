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
        PlayerPrefs.SetFloat("Player Shield", playerTypes[0].shield);
        PlayerPrefs.SetFloat("Player Health", playerTypes[0].health);
        PlayerPrefs.SetFloat("Player Speed", playerTypes[0].speed);
        PlayerPrefs.SetFloat("Player Score", 0);
    }
    public void Tank()
    {
        PlayerPrefs.SetFloat("Player Shield", playerTypes[1].shield);
        PlayerPrefs.SetFloat("Player Health", playerTypes[1].health);
        PlayerPrefs.SetFloat("Player Speed", playerTypes[1].speed);
        PlayerPrefs.SetFloat("Player Score", 0);
    }
    public void Speedy()
    {
        PlayerPrefs.SetFloat("Player Shield", playerTypes[2].shield);
        PlayerPrefs.SetFloat("Player Health", playerTypes[2].health);
        PlayerPrefs.SetFloat("Player Speed", playerTypes[2].speed);
        PlayerPrefs.SetFloat("Player Score", 0);
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
