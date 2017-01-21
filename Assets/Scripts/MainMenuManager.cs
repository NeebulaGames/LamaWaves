using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenu;

    void OnEnable()
    {
        mainMenu.SetActive(true);
    }

    void OnDisable()
    {
      mainMenu.SetActive(false);
    }
}
