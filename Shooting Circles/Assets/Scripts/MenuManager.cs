using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainItems;
    public GameObject continueButton;
    public GameObject newGameItems;

    public Player[] playerTypes;
    public Texture[] playerStats;
    public Slider categorySlider;
    public RawImage statImg;
    public Text categoryText;

    void Start()
    {
        Debug.Log(SavedData.playerScore);
        mainItems.SetActive(true);
        newGameItems.SetActive(false);

        if(SavedData.playerScore > 0)
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }
    }

    void Update()
    {
        if(categorySlider.value == 0)
        {
            categoryText.text = "Balanced";
            statImg.texture = playerStats[0];
        }
        else if (categorySlider.value == 1)
        {
            categoryText.text = "Tank";
            statImg.texture = playerStats[1];
        }
        else if (categorySlider.value == 2)
        {
            categoryText.text = "Speedy";
            statImg.texture = playerStats[2];
        }
    }


    public void CreateNewGame()
    {
        mainItems.SetActive(false);
        newGameItems.SetActive(true);
    }

    public void CancelNewGame()
    {
        newGameItems.SetActive(false);
        mainItems.SetActive(true);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void StartNewGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Level", 1);

        if(categorySlider.value == 0)
        {
            PlayerPrefs.SetFloat("Player Shield", playerTypes[0].shield);
            PlayerPrefs.SetFloat("Player Health", playerTypes[0].health);
            PlayerPrefs.SetFloat("Player Speed", playerTypes[0].speed);
            PlayerPrefs.SetFloat("Player Score", 0);
        }
        else if(categorySlider.value == 1)
        {
            PlayerPrefs.SetFloat("Player Shield", playerTypes[1].shield);
            PlayerPrefs.SetFloat("Player Health", playerTypes[1].health);
            PlayerPrefs.SetFloat("Player Speed", playerTypes[1].speed);
            PlayerPrefs.SetFloat("Player Score", 0);
        }
        else if(categorySlider.value == 2)
        {
            PlayerPrefs.SetFloat("Player Shield", playerTypes[2].shield);
            PlayerPrefs.SetFloat("Player Health", playerTypes[2].health);
            PlayerPrefs.SetFloat("Player Speed", playerTypes[2].speed);
            PlayerPrefs.SetFloat("Player Score", 0);
        }
        PlayerPrefs.Save();
        SceneManager.LoadScene("Level");
    }
}
