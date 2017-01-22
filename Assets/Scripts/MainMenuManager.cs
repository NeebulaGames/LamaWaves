using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditsMenu;
    
    void OnEnable()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    void OnDisable()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    public void OpenCredits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void CloseCredits()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }
}
